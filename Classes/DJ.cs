using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingCalculatorWF.Classes
{
   public class DJ
    {
        private int _totalDJCost;
        private string _djName;
        private string _djComments;

        public int TotalDJCost
        {
            get
            {
                return _totalDJCost;
            }
            set
            {
                _totalDJCost = value;
            }
        }
        public string DJName
        {
            get
            {
                return _djName;
            }
            set
            {
                _djName = value;
            }
        }
        public string DJComments
        {
            get
            {
                return _djComments;
            }
            set
            {
                _djComments = value;
            }
        }
    }
}
