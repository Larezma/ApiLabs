﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Interfaces.Repository;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected VitalityMasteryContext MasteryContext { get; set; }
        public RepositoryBase (VitalityMasteryContext masteryContext)
        {
            MasteryContext = masteryContext;
        }

        public async Task<List<T>> FindALL() => await MasteryContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) => 
            await MasteryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task Create(T entity) => await MasteryContext.Set<T>().AddAsync(entity);
        public async Task Update(T entity) =>  MasteryContext.Set<T>().Update(entity);
        public async Task Delete(T entity) => MasteryContext.Set<T>().Remove(entity);
    }
}
