using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeddingCalculatorWF.Classes;
using Microsoft.Win32;




namespace WeddingCalculatorWF
{
    public partial class Form1 : Form
    {

        Dictionary<string, Venue> venuesDictionary = new Dictionary<string, Venue>();
        Dictionary<string, Food> foodDictionary = new Dictionary<string, Food>();
        Dictionary<string, Beverage> beverageDictionary = new Dictionary<string, Beverage>();
        Dictionary<string, DJ> djDictionary = new Dictionary<string, DJ>();
        Dictionary<string, Florist> floristDictionary = new Dictionary<string, Florist>();
        Dictionary<string, Photographer> photoDictionary = new Dictionary<string, Photographer>();
        Dictionary<string, Food> foodBudgetDictionary = new Dictionary<string, Food>();
        Dictionary<string, Beverage> beverageBudgetDictionary = new Dictionary<string, Beverage>();


        Budget myBudget;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = ValidBudgetInfo();

            if (valid == false)
            {
                return;
            }

            int budget = int.Parse(totalBudgetAmountBox.Text);
            string budgetName = budgetNameBox.Text;

            myBudget = new Budget(budget,budgetName);
            
            myBudget.MyVenue = SelectedVenue(venueComboBox.SelectedItem.ToString());
            myBudget.MyDJ = SelectedDJ(djComboBox.SelectedItem.ToString());
            myBudget.MyFlorist = SelectedFlorist(floristComboBox.SelectedItem.ToString());
            myBudget.MyPhoto = SelectedPhoto(photoComboBox.SelectedItem.ToString());
            myBudget.MyFoodBudget = foodBudgetDictionary;
            myBudget.MyBeverageBudget = beverageBudgetDictionary;
            myBudget.BudgetBeverageCost = myBudget.CalculateBeverageCost(myBudget);
            myBudget.BudgetFoodCost = myBudget.CalculateFoodCost(myBudget);
            myBudget.TotalExpense = myBudget.CalculateExpenses(myBudget);
            myBudget.RemainingBudget = myBudget.CalculateRemainingBudget(myBudget);


            
            

            remainingBudgetLabel.Text = myBudget.RemainingBudget.ToString();


        }
        public bool ValidBudgetInfo()
        {
            bool success = int.TryParse(totalBudgetAmountBox.Text, out int total);

            if (budgetNameBox.Text == string.Empty)
            {
                MessageBox.Show("Please Ensure Budget Name is not empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (success == false)
            {
                MessageBox.Show("Please Ensure total budget amount only includes numbers", "Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (venueComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please Ensure Venue is Selected", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (djComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please Ensure DJ is Selected", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (floristComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please Ensure Florist is Selected", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (photoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please Ensure Photographer is Selected", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;    
            }
        }
        public Venue SelectedVenue(string venueName)
        {
            Venue myVenue;
            venuesDictionary.TryGetValue(venueName, out myVenue);
            return myVenue;
        }
        
        public DJ SelectedDJ(string djName)
        {
            DJ myDJ;
            djDictionary.TryGetValue(djName, out myDJ);
            return myDJ;
        }
        public Florist SelectedFlorist(string floristName)
        {
            Florist myFlorist;
            floristDictionary.TryGetValue(floristName, out myFlorist);
            return myFlorist;
        }
        public Photographer SelectedPhoto(string photoName)
        {
            Photographer myPhoto;
            photoDictionary.TryGetValue(photoName, out myPhoto);
            return myPhoto;
        }
        


        //Find a better way to do this :)
        private void addSeriveBtn_Click(object sender, EventArgs e)
        {
            bool goodData;
            goodData = ServiceIntakeValidation();

            if (goodData == false)
            {
                return;
            }

            string service = serviceSelectionBox.SelectedItem.ToString();

            if (service.ToUpper() == "VENUE")
            {
                Venue myVenue = new Venue();
                myVenue.VenueName = serviceNameBox.Text;
                myVenue.TotalVenueCost = int.Parse(serviceCostBox.Text);
                myVenue.VenueComments = serviceCommentsBox.Text;
                AddVenueItem(myVenue);
                VenueComboBox();

            }
            else if (service.ToUpper() == "FOOD")
            {
                Food myFood = new Food();
                myFood.FoodComments = serviceCommentsBox.Text;
                myFood.TotalFoodCost = int.Parse(serviceCostBox.Text);
                myFood.FoodName = serviceNameBox.Text;
                AddFoodItem(myFood);
            }
            else if (service.ToUpper() == "BEVERAGE")
            {
                Beverage myBev = new Beverage();
                myBev.BeverageComments = serviceCommentsBox.Text;
                myBev.BeverageName = serviceNameBox.Text;
                myBev.TotalBeverageCost = int.Parse(serviceCostBox.Text);
                AddBevItem(myBev);
            }
            else if (service.ToUpper() == "DJ")
            {
                DJ dj = new DJ();
                dj.DJComments = serviceCommentsBox.Text;
                dj.DJName = serviceNameBox.Text;
                dj.TotalDJCost = int.Parse(serviceCostBox.Text);
                AddDJItem(dj);
                
            }
            else if (service.ToUpper() == "PHOTOGRAPHER")
            {
                Photographer photo = new Photographer();
                photo.PhotographerComments = serviceCommentsBox.Text;
                photo.PhotographerName = serviceNameBox.Text;
                photo.TotalPhotographerCost = int.Parse(serviceCostBox.Text);
                AddPhotoItem(photo);
                
            }
            else if (service.ToUpper() == "FLORIST")
            {
                Florist florist = new Florist();
                florist.FloristComments = serviceCommentsBox.Text;
                florist.FloristName = serviceNameBox.Text;
                florist.TotalFloristCost = int.Parse(serviceCostBox.Text);
                AddFloristItem(florist);
                
            }
            else
            {
                MessageBox.Show("Please select a service", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        // validate data in the creation of vendors (comments field has no validation as that is optional)
        public bool ServiceIntakeValidation()
        {
            bool success = int.TryParse(serviceCostBox.Text, out int total);

            if (serviceCostBox.Text == string.Empty)
            {
                MessageBox.Show("Please Ensure Service Total Cost is not empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (success == false)
            {
                MessageBox.Show("Please Ensure Service Total Cost only includes numbers", "Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (serviceNameBox.Text == string.Empty )
            {
                MessageBox.Show("Please Ensure Service Name is not empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (serviceSelectionBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a service", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        //Add validation for already exsisting Dictionary Items.
        public void AddVenueItem(Venue venue)
        {
            bool valid = venuesDictionary.ContainsKey(venue.VenueName);
            if (valid == true)
            {
                MessageBox.Show("That Venue Name Already Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                venuesDictionary.Add(venue.VenueName, venue);
                VenueComboBox();
            }            
        }

        public void AddFoodItem(Food food)
        {

            bool valid = foodDictionary.ContainsKey(food.FoodName);
            if (valid == true)
            {
                MessageBox.Show("That Food Name Already Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foodDictionary.Add(food.FoodName, food);
                DisplayFoodOptions();
            }           
        }

        public void AddBevItem(Beverage bev)
        {
            bool valid = beverageDictionary.ContainsKey(bev.BeverageName);
            if (valid == true)
            {
                MessageBox.Show("That Beverage Name Already Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                beverageDictionary.Add(bev.BeverageName, bev);
                DisplayBeverageOptions();
            }            
        }

        public void AddDJItem(DJ dj)
        {
            bool valid = djDictionary.ContainsKey(dj.DJName);
            if (valid == true)
            {
                MessageBox.Show("That DJ Name Already Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                djDictionary.Add(dj.DJName, dj);
                DJComboBox();
            }
        }

        public void AddPhotoItem(Photographer photo)
        {
            bool valid = photoDictionary.ContainsKey(photo.PhotographerName);
            if (valid == true)
            {
                MessageBox.Show("That Photographer Name Already Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                photoDictionary.Add(photo.PhotographerName, photo);
                PhotoComboBox();
            }            
        }

        public void AddFloristItem(Florist florist)
        {
            bool valid = floristDictionary.ContainsKey(florist.FloristName);
            if (valid == true)
            {
                MessageBox.Show("That Florist Name Already Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                floristDictionary.Add(florist.FloristName, florist);
                FloristComboBox();
            } 
        }

        // Add validation for Remove Dictionary Items
        // Remove from dictionary functions
        public void RemoveVenueItem(string venue)
        {
            bool valid = venuesDictionary.ContainsKey(venue);
            if (valid == false)
            {
                MessageBox.Show("That Venue Name Doesn't Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                venuesDictionary.Remove(venue);
                VenueComboBox();
            }           
        }

        public void RemoveFoodItem(string food)
        {
            bool valid = foodDictionary.ContainsKey(food);
            if (valid == false)
            {
                MessageBox.Show("That Food Name Doesn't Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foodDictionary.Remove(food);
                DisplayFoodOptions();
            }            
        }

        public void RemoveBevItem(string bev)
        {
            bool valid = beverageDictionary.ContainsKey(bev);
            if (valid == false)
            {
                MessageBox.Show("That Beverage Name Doesn't Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                beverageDictionary.Remove(bev);
                DisplayBeverageOptions();
            }            
        }

        public void RemoveDJItem(string dj)
        {
            bool valid = djDictionary.ContainsKey(dj);
            if (valid == false)
            {
                MessageBox.Show("That DJ Name Doesn't Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                djDictionary.Remove(dj);
                DJComboBox();
            }
        }

        public void RemovePhotoItem(string photo)
        {
            bool valid = photoDictionary.ContainsKey(photo);
            if (valid == false)
            {
                MessageBox.Show("That Photographer Name Doesn't Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                photoDictionary.Remove(photo);
                PhotoComboBox();
            }            
        }

        public void RemoveFloristItem(string florist)
        {
            bool valid = floristDictionary.ContainsKey(florist);
            if (valid == false)
            {
                MessageBox.Show("That Florist Name Doesn't Exsists", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                floristDictionary.Remove(florist);
                FloristComboBox();
            }
        }

        // display food lists
        public void DisplayFoodOptions()
        {
            
            foodItemsBox.Items.Clear();
            

            foreach (KeyValuePair<string, Food> kvp in foodDictionary)
            {
                
                foodItemsBox.Items.Add("Name " + kvp.Key + " Amount  $" + kvp.Value.TotalFoodCost);
                
            }
        }

        public void DisplayBeverageOptions()
        {

            beverageItemsBox.Items.Clear();


            foreach (KeyValuePair<string, Beverage> kvp in beverageDictionary)
            {

                beverageItemsBox.Items.Add("Name " + kvp.Key + " Amount  $" + kvp.Value.TotalBeverageCost);

            }
        }

        private void removeServiceBtn_Click(object sender, EventArgs e)
        {
            bool goodData;
            goodData = ServiceIntakeValidation();

            if (goodData == false)
            {
                return;
            }

            string service = serviceSelectionBox.SelectedItem.ToString();

            if (service.ToUpper() == "VENUE")
            {
                RemoveVenueItem(serviceNameBox.Text);
                
            }
            else if (service.ToUpper() == "FOOD")
            {
                if (foodBudgetDictionary.ContainsKey(serviceNameBox.Text))
                {
                    MessageBox.Show("Please remove this item from your active food budget first", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    RemoveFoodItem(serviceNameBox.Text);
                }                
            }
            else if (service.ToUpper() == "BEVERAGE")
            {
                if (beverageBudgetDictionary.ContainsKey(serviceNameBox.Text))
                {
                    MessageBox.Show("Please remove this item from your active Beverage budget first", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    RemoveBevItem(serviceNameBox.Text);
                }                
            }
            else if (service.ToUpper() == "DJ")
            {
                RemoveDJItem(serviceNameBox.Text);
                            }
            else if (service.ToUpper() == "PHOTOGRAPHER")
            {
                RemovePhotoItem(serviceNameBox.Text);
                            }
            else if (service.ToUpper() == "FLORIST")
            {
                RemoveFloristItem(serviceNameBox.Text);
                            }
            else
            {
                MessageBox.Show("Please select a service", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void addFoodBtn_Click(object sender, EventArgs e)
        {
            bool inDictionary = foodDictionary.ContainsKey(foodBudgetBox.Text);
            bool inBudget = foodBudgetDictionary.ContainsKey(foodBudgetBox.Text);

            if (inDictionary == false)
            {
                MessageBox.Show("That food item does not exist", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (inBudget == true)
            {
                MessageBox.Show("That food item is already in your budget", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Food newFood = foodDictionary[foodBudgetBox.Text];
                foodBudgetDictionary.Add(newFood.FoodName, newFood);
                DisplayFoodBudget();
            }


        }
        public void DisplayFoodBudget()
        {

            selectedFoodBox.Items.Clear();


            foreach (KeyValuePair<string, Food> kvp in foodBudgetDictionary)
            {

                selectedFoodBox.Items.Add("Name " + kvp.Key + " Amount $" + kvp.Value.TotalFoodCost);

            }

            int totalFoodBudget = 0;

            foreach (KeyValuePair<string, Food> kvp in foodBudgetDictionary)
            {

                totalFoodBudget = totalFoodBudget + kvp.Value.TotalFoodCost;

            }

            totalFoodBudgetLabel.Text = totalFoodBudget.ToString();
        }

        public void DisplayBeverageBudget()
        {
            selectedBeverageBox.Items.Clear();


            foreach (KeyValuePair<string, Beverage> kvp in beverageBudgetDictionary)
            {

                selectedBeverageBox.Items.Add("Name " + kvp.Key + " Amount $" + kvp.Value.TotalBeverageCost);

            }

            int totalBeverageBudget = 0;

            foreach (KeyValuePair<string, Beverage> kvp in beverageBudgetDictionary)
            {

                totalBeverageBudget = totalBeverageBudget + kvp.Value.TotalBeverageCost;

            }

            beverageTotalLabel.Text = totalBeverageBudget.ToString();
        }
        

        private void removeFoodBtn_Click(object sender, EventArgs e)
        {
            bool inDictionary = foodDictionary.ContainsKey(foodBudgetBox.Text);

            


            if (inDictionary == false)
            {
                MessageBox.Show("That food item does not exist", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foodBudgetDictionary.Remove(foodBudgetBox.Text);
                DisplayFoodBudget();
            }
        }

        public void VenueComboBox()
        {
            venueComboBox.Items.Clear();

            foreach  (KeyValuePair<string, Venue> kvp in venuesDictionary)
            {
                venueComboBox.Items.Add(kvp.Key);
            }
        }

        public void DJComboBox()
        {
            djComboBox.Items.Clear();

            foreach (KeyValuePair<string, DJ> kvp in djDictionary)
            {
                djComboBox.Items.Add(kvp.Key);
            }
        }

        public void PhotoComboBox()
        {
            photoComboBox.Items.Clear();

            foreach (KeyValuePair<string, Photographer> kvp in photoDictionary)
            {
                photoComboBox.Items.Add(kvp.Key);
            }
        }

        public void FloristComboBox()
        {
            floristComboBox.Items.Clear();

            foreach (KeyValuePair<string, Florist> kvp in floristDictionary)
            {
                floristComboBox.Items.Add(kvp.Key);
            }
        }

        private void addBeverageBtn_Click(object sender, EventArgs e)
        {
            bool inDictionary = beverageDictionary.ContainsKey(beverageBudgetBox.Text);
            bool inBudget = beverageBudgetDictionary.ContainsKey(beverageBudgetBox.Text);


            if (inDictionary == false)
            {
                MessageBox.Show("That Beverage item does not exist", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (inBudget == true)
            {
                MessageBox.Show("That Beverage item is already in your budget", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Beverage newBeverage = beverageDictionary[beverageBudgetBox.Text];
                beverageBudgetDictionary.Add(newBeverage.BeverageName, newBeverage);                
                DisplayBeverageBudget();
            }
        }

        private void removeBeverageBtn_Click(object sender, EventArgs e)
        {
            bool inDictionary = beverageDictionary.ContainsKey(foodBudgetBox.Text);


            if (inDictionary == false)
            {
                MessageBox.Show("That Beverage item does not exist", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                beverageBudgetDictionary.Remove(foodBudgetBox.Text);
                DisplayBeverageBudget();
            }
        }

        private void venueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Venue venue;
            bool valid = venuesDictionary.TryGetValue(venueComboBox.SelectedItem.ToString(), out venue);
            venueCostLabel.Text = "Venue Cost $" + venue.TotalVenueCost.ToString();
        }

        private void djComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJ dj;
            bool valid = djDictionary.TryGetValue(djComboBox.SelectedItem.ToString(), out dj);
            djCostLabel.Text = "DJ Cost $" + dj.TotalDJCost.ToString();
        }

        private void floristComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Florist florist;
            bool valid = floristDictionary.TryGetValue(floristComboBox.SelectedItem.ToString(), out florist);
            floristCostLabel.Text = "Florist Cost $" + florist.TotalFloristCost.ToString();
        }

        private void photoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Photographer photo;
            bool valid = photoDictionary.TryGetValue(photoComboBox.SelectedItem.ToString(), out photo);
            photoCostLabel.Text = "Photographer Cost $" + photo.TotalPhotographerCost.ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Word Documents|*.docx";

            dialog.FileName = "budget";
            dialog.DefaultExt = ".docx";

            DialogResult = dialog.ShowDialog();

            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    Task.Run(() => GenerageBudgetReport(myBudget, dialog.FileName));
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error generating report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error generating report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void GenerageBudgetReport(Budget thisBudget, string reportPath)
        {
            SaveBudget wrapper = new SaveBudget();

            // Create a new Word document in memory
            wrapper.CreateBlankDocument();

            // Add a heading to the document
            wrapper.AppendHeading(String.Format("Budget Report: {0} Total Budget {1}", thisBudget.BudgetName, thisBudget.TotalBudget));
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();

            // Output the details of service 
            wrapper.AppendText(String.Format("Venue Name - {0}", thisBudget.MyVenue.VenueName), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Venue Cost is {0}", thisBudget.MyVenue.TotalVenueCost), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Comments- {0}", thisBudget.MyVenue.VenueComments), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("DJ Name - {0}", thisBudget.MyDJ.DJName), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("DJ Cost is {0}", thisBudget.MyDJ.TotalDJCost), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Comments- {0}", thisBudget.MyDJ.DJComments), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Photographer Name - {0}", thisBudget.MyPhoto.PhotographerName), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Photographer Cost is {0}", thisBudget.MyPhoto.TotalPhotographerCost), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Comments- {0}", thisBudget.MyPhoto.PhotographerComments), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Florist Name - {0}", thisBudget.MyFlorist.FloristName), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Florist Cost is {0}", thisBudget.MyFlorist.TotalFloristCost), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Comments- {0}", thisBudget.MyPhoto.PhotographerComments), false, false);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText("Your Food Items are Below", true, true);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            foreach (KeyValuePair<string, Food> kvp in thisBudget.MyFoodBudget)
            {
                wrapper.AppendText(String.Format("Food Provider Name - {0}", kvp.Value.FoodName), true, true);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText(String.Format("Food Provider Cost is {0}", kvp.Value.TotalFoodCost), false, false);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText(String.Format("Comments- {0}", kvp.Value.FoodComments), false, false);
                wrapper.InsertCarriageReturn();
                wrapper.InsertCarriageReturn();
            }
            wrapper.AppendText(String.Format("Your total Food expenses are - {0}", myBudget.BudgetFoodCost), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText("Your Beverage Items are Below", true, true);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();

            foreach (KeyValuePair<string, Beverage> kvp in thisBudget.MyBeverageBudget)
            {
                wrapper.AppendText(String.Format("Beverage Provider Name - {0}", kvp.Value.BeverageName), true, true);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText(String.Format("Beverage Provider Cost is {0}", kvp.Value.TotalBeverageCost), false, false);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText(String.Format("Comments- {0}", kvp.Value.BeverageComments), false, false);
                wrapper.InsertCarriageReturn();
                wrapper.InsertCarriageReturn();
            }
            wrapper.AppendText(String.Format("Your total Beverage expenses are - {0}", myBudget.BudgetBeverageCost), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Your total expense are - {0}", myBudget.TotalExpense), true, true);
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();
            wrapper.AppendText(String.Format("Your Remaining Budget is - {0}", myBudget.RemainingBudget), true, true);
                      

            // Save the Word document
            wrapper.SaveAs(reportPath);
        }




        


    }
}
