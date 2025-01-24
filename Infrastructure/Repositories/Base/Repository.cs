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
		private readonly MovieContext _movieContext;

		public Repository(MovieContext movieContext) {
			_movieContext = movieContext;
		}

		async Task<T> IRepository<T>.AddAsync(T entity)
		{
			await _movieContext.Set<T>().AddAsync(entity);
			await _movieContext.SaveChangesAsync();
			return entity;
		}

		async Task IRepository<T>.DeleteAsync(T entity)
		{
			_movieContext.Set<T>().Remove(entity);
			await _movieContext.SaveChangesAsync();
		}

		async Task<IReadOnlyList<T>> IRepository<T>.GetAllAsync()
		{
			return await _movieContext.Set<T>().ToListAsync();
		}

		async Task<T> IRepository<T>.GetByIdAsync(int id)
		{
			return await _movieContext.Set<T>().FindAsync(id);
			
		}

		async Task IRepository<T>.UpdateAsync(T entity)
		{
			_movieContext.Entry(entity).State = EntityState.Modified;
			await _movieContext.SaveChangesAsync();
		}
	}
}
