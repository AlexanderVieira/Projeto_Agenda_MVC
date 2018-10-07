﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        bool Save(T obj);
        T GetById(long? id);
        List<T> GetAll(String name);
        bool Update(T obj);
        bool Remove(long id);
        void Dispose();
    }
}
