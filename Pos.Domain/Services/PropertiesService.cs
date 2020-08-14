﻿using System.Collections.Generic;
using System.Linq;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Pos.Domain.Interfaces;
using Pos.Domain.Models;

namespace Pos.Domain.Services
{
    public class PropertiesService : ServicesBase, IPropertiesService
    {
        async Task<bool> IPropertiesService.AddProperty(Property property)
        {
            return await CrudService.Add(property, p => p.Name == property.Name);
        }

        async Task<bool?> IPropertiesService.UpdateProperty(Property property)
        {
            return await CrudService.Update(property, property.Id, p => p.Name == property.Name && p.Id != property.Id);
        }

        async Task<bool?> IPropertiesService.DeleteProperty(int propertyId, bool removeRelatedEntities)
        {
            var property = Context.Properties.Include(u => u.Products).FirstOrDefault(c => c.Id == propertyId);
            if (property == null) return false;
            if (property.Products.Count > 0)
                if (removeRelatedEntities)
                    Context.ProductProperties.RemoveRange(property.Products);
                else
                    return null;
            Context.Properties.Remove(property);
            await Context.SaveChangesAsync();
            return true;
        }

        async Task<Property> IPropertiesService.FindProperty(int propertyId)
        {
            return await Context.Properties.FindAsync(propertyId);
        }

        async Task<List<Property>> IPropertiesService.GetAllProperties()
        {
            return await Context.Properties.ToListAsync();
        }

        async Task<List<Property>> IPropertiesService.GetCategoryProperties(int categoryId)
        {
            var category = await Context.Categories.Include(c => c.Properties).FirstOrDefaultAsync(c => c.Id == categoryId);
            var ids = category.Properties.Select(p => p.PropertyId);
            var properties = await Context.Properties.Include(p => p.Products).Where(p => ids.Contains(p.Id)).ToListAsync();
            properties.ForEach(p =>
            {
                p.Values = p.Products.Select(v => v.Value).Distinct().Select(v=> new PropertyValue { Value = v }).ToList();
                p.Products.Clear();
            });
            return properties;
        }

    }
}
