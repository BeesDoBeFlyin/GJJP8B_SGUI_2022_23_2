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

        public Buyer GetBuyerById(int id)
        {
            foreach (var item in Buyers)
            {
                if (item.Id == id)
                    return item;
            }
            throw new Exception("No item with given id found!");
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

        public void ChangeBuyerName(int id, string newName)
        {
            if (newName == "" || newName == null)
                throw new Exception("New name can't be empty!");

            foreach (var item in this.Buyers)
            {
                if (item.Id == id)
                    item.Name = newName;
            }
        }

        public void DeleteBuyerById(int id)
        {
            foreach (var item in Buyers)
            {
                if (item.Id == id)
                    throw new NotImplementedException();
            }

            throw new Exception("There is no element with the given id!");
        }
    }
}
