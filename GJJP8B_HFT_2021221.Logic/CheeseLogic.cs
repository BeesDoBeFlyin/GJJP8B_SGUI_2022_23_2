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
    }
}
