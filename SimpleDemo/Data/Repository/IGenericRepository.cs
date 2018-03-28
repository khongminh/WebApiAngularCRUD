using SimpleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDemo.Data.Repository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetAll();

		Task<TEntity> GetByIdAsync(int id);

		Task Create(TEntity entity);

		Task Update(int id, TEntity entity);

		Task Delete(int id);
	}
}
