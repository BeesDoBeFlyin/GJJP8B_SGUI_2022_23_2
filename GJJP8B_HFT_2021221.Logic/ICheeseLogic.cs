using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public interface ICheeseLogic
    {
        void Create(Cheese cheese);
        void Delete(int id);
        Cheese GetOne(int id);
        IQueryable<Cheese> GetAll();
        void Update(Cheese cheese);
        IEnumerable<Cheese> CheesesUnderPrice(float price);
        IEnumerable<Cheese> CheesesAtPrice(float price);
        IEnumerable<Cheese> CheesesAbovePrice(float price);
        IEnumerable MadeOf(int id);
        IEnumerable<Cheese> ListCheesesMadeOfGivenMilk(int id);
        IEnumerable<Cheese> ListCheesesWithMaterialCheaperThanGiven(float price);
    }
}
