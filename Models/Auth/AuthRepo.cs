using Microsoft.EntityFrameworkCore;
using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Controllers.Auth
{
    public class AuthRepo : IAuthInterface
    {
        private readonly StudentAppContext _context;

        public AuthRepo(StudentAppContext context) {
            _context = context;
        }

        public async Task<Student> Login(string username, string pass) 
        {
            var student = await _context.Student.FirstOrDefaultAsync(x => x.Username == username);

            if (student == null)
                return null;

            return WerifyPassHash(pass, student.PasswordHash, student.PasswordSalt) ? student : null; ;
        
        }
        protected bool WerifyPassHash(string pass, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));

                if (passHash.Length != passwordHash.Length)
                    return false;

                for (int i = 0; i < passHash.Length; i++)
                    if (passHash[i] != passwordHash[i])
                        return false;
                
                return true;

            }
        }
        public async Task<Student> Register(Student student, string pass)
        {
            byte[] passHash;
            byte[] passSalt;

            CreatePassHash(pass, out passHash, out passSalt);

            student.PasswordHash = passHash;
            student.PasswordSalt = passSalt;

            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();

            return student;

        }
        protected void CreatePassHash(string pass, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            }
        }
        public async Task<bool> StudentExist(string username)
        {
            return await _context.Student.AnyAsync(x => x.Username == username);
        }

  
    }
}
