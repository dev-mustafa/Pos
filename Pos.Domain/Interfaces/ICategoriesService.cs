using System.Collections.Generic;
using System.Threading.Tasks;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Interfaces
{
    public interface ICategoriesService : IInitializer
    {
        Task<bool> AddCategory(Category category);
        Task<bool?> UpdateCategory(Category category);
        Task<bool?> DeleteCategory(int categoryId, bool removeRelatedEntities = false);
        Task<Category> FindCategory(int categoryId);
        Task<List<Category>> GetAllCategories();
        Task BindPropertiesToCategory(Category category, List<Property> properties);
        Task BindUnitsToCategory(Category category, List<Unit> units);
    }
}