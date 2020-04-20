using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Data.DBModels
{
    public class BuffetReservation
    {
        [Display(Name = "Number expected guests this day:")]
        public int AllExpectedGuests { get; set; }
        [Display(Name = "Number expected adults this day:")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number expected children this day:")]
        public int NumberOfChildren { get; set; }
        public DateTime Date { get; set; }
    }
}
