using Microsoft.EntityFrameworkCore;
using SimpleDemo.Data.Context;
using SimpleDemo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDemo.Data.Repository
{
	public class ProductRepository : IGenericRepository<Product>
	{
		private readonly ProductDbContext _dbContext;
		private readonly DbSet<Product> _dbSet;

		public ProductRepository(ProductDbContext dbContext)
		{
			this._dbContext = dbContext;
			this._dbSet = this._dbContext.Set<Product>();
		}

		public async Task Create(Product entity)
		{
			await _dbSet.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var product = await GetByIdAsync(id);
			_dbSet.Remove(product);
			await _dbContext.SaveChangesAsync();
		}

		public IQueryable<Product> GetAll()
		{
			return _dbSet.AsNoTracking();
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			return await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task Update(int id, Product entity)
		{
			_dbSet.Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
