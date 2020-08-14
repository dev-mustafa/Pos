using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Domain.Entities
{
   public class ProductDetail : TenantBase
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
