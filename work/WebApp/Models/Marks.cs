using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public partial class Marks
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Year is Mandatory")]
       // [RegularExpression(@"^(20)[0-9]\d{2}", ErrorMessage = "Invalid Year")]
        public long Yr { get; set; }
     
        [Required(ErrorMessage = "RollNo is Mandatory")]
        public long RollNo { get; set; }
        [Required(ErrorMessage = "Marks are Mandatory")]
        public long Maths { get; set; }
        [Required(ErrorMessage = "Marks are Mandatory")]
        public long Science { get; set; }
        [Required(ErrorMessage = "Marks are Mandatory")]
        public long History { get; set; }
        [Required(ErrorMessage = "Marks are Mandatory")]
        public long Geography { get; set; }
        [Required(ErrorMessage = "Marks are Mandatory")]
        public long English { get; set; }
        public decimal? MarksAverage { get; set; }
        public decimal? SmAverage { get; set; }

        public virtual Student RollNoNavigation { get; set; }
    }
}
