﻿using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class MilkController : ControllerBase
    {
        private IMilkLogic milkLogic;

        public MilkController(IMilkLogic milkLogic)
        {
            this.milkLogic = milkLogic;
        }

        [HttpGet]
        public IEnumerable<Milk> ReadAll()
        {
            return milkLogic.GetAll();
        }

        [Route("Read/{id}")]
        [HttpGet]
        public Milk Read(int id)
        {
            return milkLogic.GetMilkById(id);
        }

        [Route("Create/{newMilk}")]
        [HttpPost]
        public void Create(Milk newMilk)
        {
            milkLogic.AddMilk(newMilk);
        }

        [Route("ChangeMilkName/{id}/{name}")]
        [HttpPut]
        public void ChangeMilkName(int id, string newName)
        {
            milkLogic.ChangeMilkName(id, newName);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            milkLogic.DeleteMilkById(id);
        }

        [Route("ChangePrice/{id}/{price}")]
        [HttpPut]
        public void ChangePrice(int id, float price)
        {
            milkLogic.ChangePrice(id, price);
        }

        [Route("EditAll/{id}/{name}-{price}")]
        [HttpPut("editAll")]
        public void EditMilk(Milk milk)
        {
            milkLogic.ChangeMilkName(milk.Id, milk.Name);
            milkLogic.ChangePrice(milk.Id, milk.Price);
        }

        [Route("UnderPrice/{price}")]
        [HttpGet]
        public IEnumerable<Milk> GetMilksUnderPrce(float price)
        {
            return milkLogic.MilksUnderPrice(price);
        }

        [Route("AtPrice/{price}")]
        [HttpGet]
        public IEnumerable<Milk> GetMilksAtPricePoint(float price)
        {
            return milkLogic.MilksAtPricePoint(price);
        }
        
        [Route("AbovePrice/{price}")]
        [HttpGet]
        public IEnumerable<Milk> GetMilksAbovePrice(float price)
        {
            return milkLogic.MilksAbovePrice(price);
        }
    }
}
