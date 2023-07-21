using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoStudio.Models
{
    public class Booking
    {
        public int ReservationId { get; set; }
        public int CustomerID { get; set; }
        public string EvenType { get; set; }
        public string FunctionType { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> FromTime { get; set; }
        public Nullable<System.DateTime> ToTime { get; set; }
        public Nullable<bool> IsPayCompleate { get; set; }
        public Nullable<bool> IsReservationCompleate { get; set; }
    }
}