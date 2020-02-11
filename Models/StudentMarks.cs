using System;
using System.Collections.Generic;

namespace StudentsApp.Models
{
    public partial class StudentMarks
    {
        public int MarkId { get; set; }
        public int Mark { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
