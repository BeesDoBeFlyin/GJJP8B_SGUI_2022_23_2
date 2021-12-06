using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public interface IMilkLogic
    {
        IQueryable<Milk> GetAll();
        void AddMilk(Milk mk);
        Milk GetMilkById(int id);
        void ChangeMilkName(int id, string newName);
        void DeleteMilkById(int id);
        void ChangePrice(int id, float newPrice);
        float ReturnPrice(int id);
        IEnumerable<Milk> MilksUnderPrice(float price);
        IEnumerable<Milk> MilksAtPricePoint(float price);
        IEnumerable<Milk> MilksAbovePrice(float price);
    }
}
