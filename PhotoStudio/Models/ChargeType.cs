using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoStudio.Models
{
    public class ChargeType

    {
        [Required(ErrorMessage = "* Charge Type Code Can't be Empty")]
        public string ChargeTypeCode { get; set; }


        [Required(ErrorMessage = "* Charge Type Discription  Can't be Empty")]
        public string Discription { get; set; }


        [Required(ErrorMessage = "* Please Select EventType ")]
        public string EventType { get; set; }


        [Required(ErrorMessage = "* Charge Type Price Can't be Empty")]
        public Nullable<decimal> Price { get; set; }

    }
}