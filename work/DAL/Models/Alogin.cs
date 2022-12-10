using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Alogin
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Passwd { get; set; }
    }
}
