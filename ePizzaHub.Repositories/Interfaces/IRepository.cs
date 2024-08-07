﻿using ePizzaHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object entity);
        int SaveChanges();
      
    }
}
