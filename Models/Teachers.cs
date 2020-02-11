using System;
using System.Collections.Generic;

namespace StudentsApp.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            Subject = new HashSet<Subject>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
    }
}
