using API.Core.DbModels;

namespace API.Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
	{
		Task<T> GetByIdAsync(int id);

		Task<IReadOnlyList<T>> ListAllAsync();
	}
}

