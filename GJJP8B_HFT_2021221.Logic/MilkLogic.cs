using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Logic
{
    public class MilkLogic : IMilkLogic
    {
        private List<Milk> Milks { get; set; }

        public int MilkCount
        {
            get
            {
                return this.Milks.Count;
            }
        }

        public MilkLogic()
        {
            this.Milks = new List<Milk>();
        }

        public void AddMilk(Milk mk)
        {
            this.Milks.Add(mk);
        }

        public Milk GetMilkByIndex(int index)
        {
            return this.Milks[index];
        }

        public List<Milk> GetAll()
        {
            return this.Milks;
        }

        public void ChangeMilkName(int id, string newName)
        {
            if (newName == "" || newName == null)
                throw new Exception("New name can't be empty!");

            if (newName.Length > 80)
                throw new Exception("New name is too long! (Max 80 characters)");

            foreach (var item in this.Milks)
            {
                if (item.Name == newName)
                    throw new Exception("New name can't be the name of an already existing Milk!");
            }

            foreach (var item in this.Milks)
            {
                if (item.Id == id)
                    item.Name = newName;
            }
        }
    }
}
