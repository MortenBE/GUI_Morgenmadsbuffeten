using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Data.DBModels
{
    public class CheckedInGuest
    {    
        public int RoomNumber { get; set; }       
        public int NumberOfAdultsCheckedIn { get; set; }        
        public int NumberOfChildrenCheckedIn { get; set; } 
        public DateTime Date { get; set; }



    }
}
