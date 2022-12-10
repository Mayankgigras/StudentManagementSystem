using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Marks>();
        }

        public long RollNo { get; set; }
        public long JoiningYear { get; set; }
        public string StudentFname { get; set; }
        public string StudentLname { get; set; }
        public long Contact { get; set; }
        public string FatherName { get; set; }
        public string Class { get; set; }

        public virtual ICollection<Marks> Marks { get; set; }
    }
}
