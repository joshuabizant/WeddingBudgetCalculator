using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
    public class Beverage
    {
        private int _totalBeverageCost;
        private string _beverageName;
        private string _beverageComments;

        public int TotalBeverageCost
        {
            get
            {
                return _totalBeverageCost;
            }
            set
            {
                _totalBeverageCost = value;
            }
        }
        public string BeverageName
        {
            get
            {
                return _beverageName;
            }
            set
            {
                _beverageName = value;
            }
        }
        public string BeverageComments
        {
            get
            {
                return _beverageComments;
            }
            set
            {
                _beverageComments = value;
            }
        }
    }
}
