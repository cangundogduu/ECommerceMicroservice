using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories;
using ECommerce.Catalog.Settings;

namespace ECommerce.Catalog.Services.CategoryServices
{
    public class CategoryService : GenericRepository<Category>, ICategoryService
    {
        public CategoryService(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {

        }
    }
}
