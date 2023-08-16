using API.Core.DbModels;

namespace API.Core.Interfaces
{
    public interface IProductRepository
	{
		Task<Product> GetProductByIdAsync(int id);

		Task<IReadOnlyList<Product>> GetProductAsync();

		Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
    }
}

