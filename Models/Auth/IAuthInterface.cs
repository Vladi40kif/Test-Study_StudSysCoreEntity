using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Controllers.Auth
{
    interface IAuthInterface
    {
        public Task<Student> Register(Student student, string pass);
        public Task<Student> Login(string username, string pass);
        public Task<bool> StudentExist(string username);


    }
}
