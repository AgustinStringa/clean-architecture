using Core.Entities.Base;
using Core.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
	public class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly MovieContext MovieContext;

		public Repository(MovieContext movieContext) {
			MovieContext = movieContext;
		}

		async Task<T> IRepository<T>.AddAsync(T entity)
		{
			await MovieContext.Set<T>().AddAsync(entity);
			await MovieContext.SaveChangesAsync();
			return entity;
		}

		async Task IRepository<T>.DeleteAsync(T entity)
		{
			MovieContext.Set<T>().Remove(entity);
			await MovieContext.SaveChangesAsync();
		}

		async Task<IReadOnlyList<T>> IRepository<T>.GetAllAsync()
		{
			return await MovieContext.Set<T>().ToListAsync();
		}

		async Task<T> IRepository<T>.GetByIdAsync(int id)
		{
			return await MovieContext.Set<T>().FindAsync(id);
			
		}

		async Task IRepository<T>.UpdateAsync(T entity)
		{
			MovieContext.Entry(entity).State = EntityState.Modified;
			await MovieContext.SaveChangesAsync();
		}
	}
}
