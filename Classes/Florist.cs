using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
   public class Florist
    {
        private int _totalFloristCost;
        private string _floristName;
        private string _floristComments;

        public int TotalFloristCost
        {
            get
            {
                return _totalFloristCost;
            }
            set
            {
                _totalFloristCost = value;
            }
        }
        public string FloristName
        {
            get
            {
                return _floristName;
            }
            set
            {
                _floristName = value;
            }
        }
        public string FloristComments
        {
            get
            {
                return _floristComments;
            }
            set
            {
                _floristComments = value;
            }
        }
    }
}
