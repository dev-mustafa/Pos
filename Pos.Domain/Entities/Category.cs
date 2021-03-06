﻿using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            Products = new List<Product>();
            Units = new List<CategoryUnit>();
            Properties = new List<CategoryProperty>();
        }

        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CategoryUnit> Units { get; set; }
        public virtual ICollection<CategoryProperty> Properties { get; set; }


    }
}
