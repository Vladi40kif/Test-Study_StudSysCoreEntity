using System;
using System.Collections.Generic;

namespace StudentsApp.Models
{
    public partial class Group
    {
        public Group()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
