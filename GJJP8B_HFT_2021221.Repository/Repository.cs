using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;

namespace GJJP8B_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public CheeseContext context;

        public Repository(CheeseContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
        }

        public IQueryable<T> ReturnAll()
        {
            return this.context.Set<T>();
        }

        public void Delete(int id)
        {
            this.context.Set<T>().Remove(ReturnOne(id));
            this.context.SaveChanges();
        }

        public abstract T ReturnOne(int id);
        public abstract void Update(T entity);
    }
}
