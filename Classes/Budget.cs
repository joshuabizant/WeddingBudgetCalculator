using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
    class Budget
    {
        private string _budgetName;
        private int _totalBudget;
        private int _remainingBudget;
        private int _totalExpenses;
        private int _budgetFoodCost;
        private int _budgetBeverageCost;

        private Venue _myVenue = new Venue();
        private DJ _myDJ = new DJ();
        private Photographer _myPhoto = new Photographer();
        private Florist _myFlorist = new Florist();
        private Dictionary<string, Food> _myFoodBudget = new Dictionary<string, Food>();
        private Dictionary<string, Beverage> _myBeverageBudget = new Dictionary<string, Beverage>();
        public Venue MyVenue
        {
            get
            {
                return _myVenue;
            }
            set
            {
                _myVenue = value;
            }
        }
        public DJ MyDJ
        {
            get
            {
                return _myDJ;
            }
            set
            {
                _myDJ = value;
            }
        }
        public Photographer MyPhoto
        {
            get
            {
                return _myPhoto;
            }
            set
            {
                _myPhoto = value;
            }
        }
        public Florist MyFlorist
        {
            get
            {
                return _myFlorist;
            }
            set
            {
                _myFlorist = value;
            }
        }
        public Dictionary<string, Food> MyFoodBudget
        {
            get
            {
                return _myFoodBudget;
            }
            set
            {
                _myFoodBudget = value;
            }
        }
        public Dictionary<string, Beverage> MyBeverageBudget
        {
            get
            {
                return _myBeverageBudget;
            }
            set
            {
                _myBeverageBudget = value;
            }
        }

        public int BudgetFoodCost
        {
            get
            {
                return _budgetFoodCost;
            }
            set
            {
                _budgetFoodCost = value;
            }
        }
        public int BudgetBeverageCost
        {
            get
            {
                return _budgetBeverageCost;
            }
            set
            {
                _budgetBeverageCost = value;
            }
        }
        public string BudgetName
        {
            get
            {
                return _budgetName;
            }
            set
            {
                _budgetName = value;
            }
        }
         public int TotalBudget
        {
            get
            {
                return _totalBudget;
            }
            set
            {
                _totalBudget = value;
            }
        }
        public int RemainingBudget
        {
            get
            {
                return _remainingBudget;
            }
            set
            {
                _remainingBudget = value;
            }
        }
        public int TotalExpense
        {
            get
            {
                return _totalExpenses;

            }
            set
            {
                _totalExpenses = value;
            }
        }




        public Budget (int budget, string name)
        {
            
            TotalBudget = budget;
            BudgetName = name;



            //int venueCost = venue.TotalVenueCost;
            //int djCost = dj.TotalDJCost;
            //int floristCost = florist.TotalFloristCost;
            //int photoCost = photographer.TotalPhotographerCost;

            //TotalExpense = CalculateExpenses(foodCost, bevCost, venueCost, djCost, floristCost, photoCost);
            //RemainingBudget = CalculateBudget(budget, TotalExpense);
        }

        public int CalculateFoodCost(Budget budget)
        {
            int totalFoodBudget = 0;
            

            foreach (KeyValuePair<string, Food> kvp in budget.MyFoodBudget)
            {

                totalFoodBudget = totalFoodBudget + kvp.Value.TotalFoodCost;

            }

            return  totalFoodBudget;
        }

        public int CalculateBeverageCost(Budget budget)
        {
            int totalBevBudget = 0;

            foreach (KeyValuePair<string, Beverage> kvp in budget.MyBeverageBudget)
            {

                totalBevBudget = totalBevBudget + kvp.Value.TotalBeverageCost;
            }
            return totalBevBudget;
        }

        public int CalculateRemainingBudget(Budget budget)
        {
            int remainingBudget = budget.TotalBudget - budget.TotalExpense;

            return remainingBudget;
        }

        public int CalculateExpenses (Budget budget)
        {
            int expenses = (budget.MyVenue.TotalVenueCost + budget.MyDJ.TotalDJCost + budget.MyFlorist.TotalFloristCost + budget.MyPhoto.TotalPhotographerCost + budget.BudgetBeverageCost + budget.BudgetFoodCost);

            return expenses;
        }



       





    }
}
