using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Marks
    {
        public string Id { get; set; }
        public long Yr { get; set; }
        public long RollNo { get; set; }
        public long Maths { get; set; }
        public long Science { get; set; }
        public long History { get; set; }
        public long Geography { get; set; }
        public long English { get; set; }
        public decimal? MarksAverage { get; set; }
        public decimal? SmAverage { get; set; }

        public virtual Student RollNoNavigation { get; set; }
    }
}
