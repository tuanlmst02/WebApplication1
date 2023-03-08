using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContexts;
using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

		public Task<Product> CreateUpdateProduct(ProductDto productDto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteProduct(int productId)
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetProductById(int ProducId)
		{
			throw new NotImplementedException();
		}

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}