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
        IQueryable<Cheese> GetAll();
        void AddCheese(Cheese ch);
        void ChangeCheeseName(int id, string newName);
        Cheese GetCheeseById(int id);
        void DeleteCheeseById(int id);
        void ChangePrice(int id, float newPrice);
        void ChangeMilk(int id, int newMilkId);
        float ReturnPrice(int id);
        IEnumerable<Cheese> CheesesUnderPrice(float price);
        IEnumerable<Cheese> CheesesAtPrice(float price);
        IEnumerable<Cheese> CheesesAbovePrice(float price);
        IEnumerable MadeOf(int id);
        IEnumerable<Cheese> ListCheesesMadeOfGivenMilk(int id);
        IEnumerable<Cheese> ListCheesesWithMaterialCheaperThanGiven(float price);
    }
}
