using System.Collections.Generic;

namespace Pos.Domain.Entities
{
   public class Unit : TenantBase
    {
        public Unit()
        {
            Categories = new List<CategoryUnit>();
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryUnit> Categories { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
