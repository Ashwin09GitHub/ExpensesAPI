using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Business
{
    public class UserClass
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mobile { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}