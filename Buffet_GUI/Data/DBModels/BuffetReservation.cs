using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Data.DBModels
{
    public class BuffetReservation
    {       
        public int AllExpectedGuests { get; set; }        
        public int NumberOfAdults { get; set; }       
        public int NumberOfChildren { get; set; }   
        public DateTime Date { get; set; }
    }
}
