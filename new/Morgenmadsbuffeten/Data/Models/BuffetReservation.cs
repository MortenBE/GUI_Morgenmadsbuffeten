using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Data.Models
{
    public class BuffetReservation
    {
        public int RoomNumber { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfAdults { get; set; }
        public bool CheckedIn { get; set; }
        public DateTime Date { get; set; }
    }
}
