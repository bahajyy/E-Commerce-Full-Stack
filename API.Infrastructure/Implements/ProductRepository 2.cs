using System.Linq;
using API.Core.DbModels;
using API.Core.Interfaces;
using API.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
	{
        private readonly StoreContext _context;

		public ProductRepository(StoreContext context)
		{
            _context = context;
		}

        async Task<Product> IProductRepository.GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.productBrand).Include(p => p.productType)
                .FirstOrDefaultAsync(p => p.id == id);
        }
        
        async Task<IReadOnlyList<Product>> IProductRepository.GetProductAsync()
        {
            return await _context.Products.Include(p=> p.productBrand).Include(p=> p.productType)
                .ToListAsync();
        }

        async Task<IReadOnlyList<ProductType>> IProductRepository.GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        async Task<IReadOnlyList<ProductBrand>> IProductRepository.GetProductBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}

