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
        void Create(Milk milk);
        void Delete(int id);
        Milk GetOne(int id);
        IQueryable<Milk> GetAll();
        void Update(Milk milk);
        IEnumerable<Milk> MilksUnderPrice(float price);
        IEnumerable<Milk> MilksAtPricePoint(float price);
        IEnumerable<Milk> MilksAbovePrice(float price);
    }
}
