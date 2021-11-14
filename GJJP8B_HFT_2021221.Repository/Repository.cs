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
        private CheeseContext context;

        public Repository(CheeseContext context)
        {
            this.context = context;
        }

        public abstract void Delete(int id);

        public abstract void Insert(T entity);

        public IQueryable<T> ReturnAll()
        {
            return this.context.Set<T>();
        }

        protected CheeseContext Context { get => this.context; set => this.context = value; }

        public abstract T ReturnOne(int id);
    }
}
