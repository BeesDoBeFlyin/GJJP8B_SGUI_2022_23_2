using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public class BuyerLogic : IBuyerLogic
    {

        private List<Buyer> Buyers { get; set; }

        public BuyerLogic()
        {
            this.Buyers = new List<Buyer>();
        }
        public int BuyerCount
        {
            get
            {
                return this.Buyers.Count;
            }
        }

        public void AddBuyer(Buyer buy)
        {
            this.Buyers.Add(buy);
        }

        public List<Buyer> GetAll()
        {
            return this.Buyers;
        }

        public Buyer GetBuyerByIndex(int index)
        {
            return this.Buyers[index];
        }
    }
}
