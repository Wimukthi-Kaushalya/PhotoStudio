using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoStudio.Models
{
    public class Account
    {
        public int CustomerID { get; set; }

        //[Required(ErrorMessage = "* Customet Title Can't be Empty")]
        public string CustometTitle { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress3 { get; set; }
        public string CutomerContact { get; set; }
        public string CustomerEmail { get; set; }
        public Nullable<System.DateTime> RegistrerdDate { get; set; }

        public string Password { get; set; }


    }
}