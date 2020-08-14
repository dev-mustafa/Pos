using System.Collections.Generic;
using System.Linq;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Pos.Domain.Interfaces;

namespace Pos.Domain.Services
{
    public class CategoriesService : ServicesBase, ICategoriesService
    {
        async Task<bool> ICategoriesService.AddCategory(Category category)
        {
            if (await Context.Categories.AnyAsync(c => c.Name == category.Name))
                return false;

            Context.Categories.Add(category);
            foreach (var unit in category.Units) { Context.Entry(unit).State = EntityState.Unchanged; }
            foreach (var proprty in category.Properties) { Context.Entry(proprty).State = EntityState.Unchanged; }
            return await Context.SaveChangesAsync() > 0;

        }
        async Task<bool?> ICategoriesService.UpdateCategory(Category category)
        {
            var oldCategory = await Context.Categories.Include(c => c.Properties).Include(c => c.Units).FirstOrDefaultAsync(c => c.Id == category.Id);
            if (oldCategory == null) return null;
            if (await Context.Categories.AnyAsync(c => c.Name == category.Name && c.Id != category.Id))
                return false;
            oldCategory.Name = category.Name;
            var products = await Context.Products.Where(p => p.CategoryId == category.Id).Select(p => p.Id).ToListAsync();

            oldCategory.Properties.Where(e => category.Properties.All(p => p.PropertyId != e.PropertyId)).ToList().ForEach(p =>
                        {
                            Context.ProductProperties.RemoveRange(Context.ProductProperties.Where(pr => pr.PropertyId == p.PropertyId && products.Contains(pr.ProductId)));
                            oldCategory.Properties.Remove(p);
                        });
            category.Properties.Where(e => oldCategory.Properties.All(p => p.PropertyId != e.PropertyId)).ToList().ForEach(p =>
            {
                Context.ProductProperties.AddRange(products.Select(id => new ProductProperty
                {
                    ProductId = id,
                    PropertyId = p.PropertyId,
                    Value = ""
                }));
                oldCategory.Properties.Add(p);
                Context.Entry(p).State = EntityState.Unchanged;
            });
            oldCategory.Units.Where(e => category.Units.All(p => p.UnitId != e.UnitId)).ToList().ForEach(p => oldCategory.Units.Remove(p));
            category.Units.Where(e => oldCategory.Units.All(p => p.UnitId != e.UnitId)).ToList().ForEach(p =>
            {
                oldCategory.Units.Add(p);
                Context.Entry(p).State = EntityState.Unchanged;
            });

            await Context.SaveChangesAsync();
            return true;
        }
        async Task<bool?> ICategoriesService.DeleteCategory(int categoryId, bool removeRelatedEntities)
        {
            var category = Context.Categories.Include(u => u.Products).FirstOrDefault(c => c.Id == categoryId);
            if (category == null) return false;
            if (category.Products.Count > 0)
                if (removeRelatedEntities)
                    Context.Products.RemoveRange(category.Products);
                else
                    return null;
            Context.Categories.Remove(category);
            await Context.SaveChangesAsync();
            return true;
        }
        async Task<Category> ICategoriesService.FindCategory(int categoryId)
        {
            return await Context.Categories.FindAsync(categoryId);
        }
        async Task<List<Category>> ICategoriesService.GetAllCategories()
        {
            return await Context.Categories.Include(c => c.Properties).Include(c => c.Units).ToListAsync();
        }
        async Task ICategoriesService.BindPropertiesToCategory(Category category, List<Property> properties)
        {
            properties.ForEach(property => category.Properties.Add(new CategoryProperty {PropertyId = property.Id}));
            await Context.SaveChangesAsync();
        }
        async Task ICategoriesService.BindUnitsToCategory(Category category, List<Unit> units)
        {
            units.ForEach(unit => category.Units.Add(new CategoryUnit{ UnitId =  unit.Id }));
            await Context.SaveChangesAsync();
        }

    }
}
