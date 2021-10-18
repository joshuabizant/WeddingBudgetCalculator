using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
   public class Food
    {
        private int _totalFoodCost;
        private string _foodName;
        private string _foodComments;

        public int TotalFoodCost
        {
            get
            {
                return _totalFoodCost;
            }
            set
            {
                _totalFoodCost = value;
            }
        }
        public string FoodName
        {
            get
            {
                return _foodName;
            }
            set
            {
                _foodName = value;
            }
        }
        public string FoodComments
        {
            get
            {
                return _foodComments;
            }
            set
            {
                _foodComments = value;
            }
        }
    }
}
