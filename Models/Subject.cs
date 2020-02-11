using System;
using System.Collections.Generic;

namespace StudentsApp.Models
{
    public partial class Subject
    {
        public Subject()
        {
            StudentMarks = new HashSet<StudentMarks>();
        }

        public int SubjId { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teachers Teacher { get; set; }
        public virtual ICollection<StudentMarks> StudentMarks { get; set; }
    }
}
