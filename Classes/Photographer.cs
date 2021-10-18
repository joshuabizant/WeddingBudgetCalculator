using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
    public class Photographer
    {
        private int _totalPhotographerCost;
        private string _photographerName;
        private string _photographerComments;

        public int TotalPhotographerCost
        {
            get
            {
                return _totalPhotographerCost;
            }
            set
            {
                _totalPhotographerCost = value;
            }
        }
        public string PhotographerName
        {
            get
            {
                return _photographerName;
            }
            set
            {
                _photographerName = value;
            }
        }
        public string PhotographerComments
        {
            get
            {
                return _photographerComments;
            }
            set
            {
                _photographerComments = value;
            }
        }
    }
}
