using Buffet_GUI.Data.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Models
{
    public class KitchenViewModel
    {
        public KitchenViewModel(List<BuffetReservation> expectedGuestsInfo, List<CheckedInGuest> checkedInEntries)
        {
            var TotalChildren = 0;
            var TotalAdults = 0;
            var TotalCheckedIn = 0;

            var TotalChildrenExpected = 0;
            var TotalAdultsExpected = 0;
            var TotalCheckedInExpected = 0;

            checkedInEntries.ForEach(g =>
            {
                TotalChildren += g.NumberOfChildrenCheckedIn;
                TotalAdults += g.NumberOfAdultsCheckedIn;
            });

            TotalCheckedIn = TotalAdults + TotalChildren;

            expectedGuestsInfo.ForEach(g =>
            {
                TotalChildrenExpected += g.NumberOfChildren;
                TotalAdultsExpected += g.NumberOfAdults;
                TotalCheckedInExpected += g.AllExpectedGuests;
            });
            
            TotalChildrenNotCheckedIn = TotalChildrenExpected - TotalChildren;
            TotalAdultsNotCheckedIn = TotalAdultsExpected - TotalAdults;
            TotalNotCheckedIn = TotalCheckedInExpected - TotalCheckedIn;
        }
        public int TotalChildrenNotCheckedIn { get; set; }
        public int TotalAdultsNotCheckedIn { get; set; }
        public int TotalNotCheckedIn { get; set; }

    }
}
