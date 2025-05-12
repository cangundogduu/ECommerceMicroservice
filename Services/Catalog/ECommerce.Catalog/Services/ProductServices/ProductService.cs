using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories;
using ECommerce.Catalog.Settings;

namespace ECommerce.Catalog.Services.ProductServices
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        public ProductService(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {

        }
    }
}
