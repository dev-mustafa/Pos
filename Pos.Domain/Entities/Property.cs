using Pos.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Domain.Entities
{
   public class Property : EntityBase
    {
        public Property()
        {
            Products = new List<ProductProperty>();
            Categories = new List<CategoryProperty>();
            Values = new List<PropertyValue>();
        }

        public string Name { get; set; }
        public virtual ICollection<ProductProperty> Products { get; set; }
        public virtual ICollection<CategoryProperty> Categories { get; set; }
        [NotMapped]
        public List<PropertyValue> Values { get; set; }
    }
}
