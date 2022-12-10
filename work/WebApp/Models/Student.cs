using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Marks>();
        }
        [Required(ErrorMessage ="RollNo is mandatory")]
        public int RollNo { get; set; }
        [Required(ErrorMessage ="Joining Year is mandatory")]
         //[RegularExpression("^(20)[0 - 9]{4}",ErrorMessage ="Enter a Valid Year")]
        //[StringLength(MinimumLength = 10)]
        public int JoiningYear { get; set; }
        [Required(ErrorMessage = "Student First Name is mandatory")]
        public string StudentFname { get; set; }
        [Required(ErrorMessage = "Student Last Name is mandatory")]
        public string StudentLname { get; set; }
        [Required(ErrorMessage = "Contact is mandatory")]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Invalid Contact")]
        public long Contact { get; set; }
        [Required(ErrorMessage = "Father's Name is mandatory")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Class is Mandatory")]
        [RegularExpression(@"^[A-D]",ErrorMessage = "Invalid Class")]
        public Char Class { get; set; }

        public virtual ICollection<Marks> Marks { get; set; }
    }
}
