using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Data.DBModels
{
    public class CheckedInGuest
    {
        [Display(Name = "Room Number:")]
        public int RoomNumber { get; set; }
        [Display(Name = "Number of adults checking in:")]
        public int NumberOfAdultsCheckedIn { get; set; }
        [Display(Name = "Number of Children checking in:")]
        public int NumberOfChildrenCheckedIn { get; set; }
        public DateTime Date { get; set; }



    }
}
