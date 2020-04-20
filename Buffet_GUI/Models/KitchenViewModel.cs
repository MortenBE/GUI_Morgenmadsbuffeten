using Buffet_GUI.Data.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Models
{
    public class KitchenViewModel
    {
        public KitchenViewModel(BuffetReservation expectedGuestsInfo, List<CheckedInGuest> checkedInEntries)
        {
            var TotalChildren = 0;
            var TotalAdults = 0;
            var TotalCheckedIn = 0;
            
            checkedInEntries.ForEach(g =>
            {
                TotalChildren += g.NumberOfChildrenCheckedIn;
                TotalAdults += g.NumberOfAdultsCheckedIn;
            });

            TotalCheckedIn = TotalAdults + TotalChildren;

            TotalChildrenNotCheckedIn = expectedGuestsInfo.NumberOfChildren - TotalChildren;
            TotalAdultsNotCheckedIn = expectedGuestsInfo.NumberOfAdults - TotalAdults;
            TotalNotCheckedIn = expectedGuestsInfo.AllExpectedGuests - TotalCheckedIn;

        }
        public int TotalChildrenNotCheckedIn { get; set; }
        public int TotalAdultsNotCheckedIn { get; set; }
        public int TotalNotCheckedIn { get; set; }

    }
}
