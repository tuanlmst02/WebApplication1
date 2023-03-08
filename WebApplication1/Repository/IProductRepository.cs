using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<Product> GetProductById(int ProducId);
        Task<Product> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
