using System.Collections.Generic;

namespace Pos.Domain.Entities
{
   public class Unit : EntityBase
    {
        public Unit()
        {
            Categories = new List<CategoryUnit>();
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public ICollection<CategoryUnit> Categories { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
