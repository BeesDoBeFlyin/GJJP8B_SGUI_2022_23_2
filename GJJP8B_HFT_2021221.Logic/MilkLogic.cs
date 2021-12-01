﻿using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GJJP8B_HFT_2021221.Logic
{
    public class MilkLogic : IMilkLogic
    {
        private IMilkRepository repository;


        public MilkLogic(IMilkRepository milkRepository)
        {
            this.repository=milkRepository;
        }

        public Milk GetMilkById(int id)
        {
           return repository.ReturnOne(id);
        }

        public void AddMilk(Milk mk)
        {
            repository.Insert(mk);
        }

        public IQueryable<Milk> GetAll()
        {
            return repository.ReturnAll();
        }

        public void ChangeMilkName(int id, string newName)
        {
            repository.ChangeName(id, newName);
        }

        public void DeleteMilkById(int id)
        {
            repository.Delete(id);
        }

        public void ChangePrice(int id, int newPrice)
        {
            repository.ChangePrice(id, newPrice);
        }
    }
}
