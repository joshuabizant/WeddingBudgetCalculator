using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
   public class Venue
    {
        private int _totalVenueCost;
        private string _venueName;
        private string _venueComments;

        public int TotalVenueCost
        {
            get
            {
                return _totalVenueCost;
            }
            set
            {
                _totalVenueCost = value;
            }
        }
        public string VenueName
        {
            get
            {
                return _venueName;
            }
            set
            {
                _venueName = value;
            }
        }
        public string VenueComments
        {
            get
            {
                return _venueComments;
            }
            set
            {
                _venueComments = value;
            }
        }
    }
}
