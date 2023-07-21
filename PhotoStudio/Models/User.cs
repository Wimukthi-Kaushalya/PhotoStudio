using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoStudio.Models
{
    public class User
    {
        public int UserId { get; set; }


        [Required(ErrorMessage = "* First Name  Can't be Empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Last Name Can't be Empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* DOB Can't be Empty")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required(ErrorMessage = "* Address Can't be Empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = " * Contact Numbe is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "* Contact Number should contain only numbers.")]
        public string ContactNum { get; set; }

        [Required(ErrorMessage = "* E-mail Address Can't be Empty")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "* Password Can't be Empty")]
        public string Password { get; set; }

        [Required(ErrorMessage = "* Please Select User Type")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "* Please Select user branch")]
        public Nullable<int> BrachID { get; set; }

    }
}