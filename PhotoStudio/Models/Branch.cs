using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebForms = System.Web.UI.WebControls;

namespace PhotoStudio.Models
{
    public class Branch
    {
        public int BarnchID { get; set; }

        [Required(ErrorMessage = "* Branch Name Can't be Empty")]
        public string BranchName { get; set; }


        [Required(ErrorMessage = "* Branch Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "* Branch Contact Numbe is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "* Contact Number should contain only numbers.")]
        public string ContactNumbe { get; set; }


        [Required(ErrorMessage = "* Branch E-mail is required.")]
        public string BranchEmail { get; set; }


        [Required(ErrorMessage = "* Please Select Branch Manager.")]
        public Nullable<int> MangerID { get; set; }


        public List<int> BranchList { get; set; }

    }
    //public class BranchValidate
    //{
    //    [Required(ErrorMessage = "Please enter the Branch Name.")]
    //    public string BranchName { get; set; }
    //}

}