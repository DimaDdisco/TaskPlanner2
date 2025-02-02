﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner2.Models.Repositories
{
    interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
