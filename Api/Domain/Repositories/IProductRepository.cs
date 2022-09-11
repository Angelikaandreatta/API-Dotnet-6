using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task<ICollection<Product>> GetProduct();
        Task<Product> Create(Product product);
        Task Edit(Product product);
        Task Delete(Product product);
    }
}
