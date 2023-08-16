using API.Core.DbModels;
using API.Core.Interfaces;
using API.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{
    public class GenericRepository<T> :IGenericRepository<T> where T : BaseEntity
	{
        private readonly StoreContext _context;

		public GenericRepository(StoreContext context)
		{
            _context = context;
		}

        async Task<T> IGenericRepository<T>.GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        async Task<IReadOnlyList<T>> IGenericRepository<T>.ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}

