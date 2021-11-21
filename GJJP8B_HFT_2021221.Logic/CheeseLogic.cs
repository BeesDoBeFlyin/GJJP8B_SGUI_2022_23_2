using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public class CheeseLogic : ICheeseLogic
    {
        public int CheeseCount
        {
            get
            {
                return this.Cheeses.Count;
            }
        }

        private List<Cheese> Cheeses { get; set; }

        public CheeseLogic()
        {
            this.Cheeses = new List<Cheese>();
        }

        public void AddCheese(Cheese ch)
        {
            this.Cheeses.Add(ch);
        }

        public List<Cheese> GetAll()
        {
            return this.Cheeses;
        }

        public Cheese GetCheeseByIndex(int index)
        {
            return this.Cheeses[index];
        }

        public void ChangeCheeseName(int id, string newName)
        {
            if (newName == "" || newName == null)
                throw new Exception("New name can't be empty!");

            if (newName.Length > 80)
                throw new Exception("New name is too long! (Max 80 characters)");

            foreach (var item in this.Cheeses)
            {
                if (item.Name == newName)
                    throw new Exception("New name can't be the name of an already existing Cheese!");
            }

            foreach (var item in this.Cheeses)
            {
                if (item.Id == id)
                    item.Name = newName;
            }
        }
    }
}
