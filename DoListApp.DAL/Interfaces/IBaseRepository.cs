﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {

        IQueryable<T> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);


    }
}
