using System;
using System.Collections.Generic;

namespace StudentsApp.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentMarks = new HashSet<StudentMarks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string Username { get; set; }
        public int? GroupId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<StudentMarks> StudentMarks { get; set; }
    }
}
