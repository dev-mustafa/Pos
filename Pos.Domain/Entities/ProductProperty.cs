using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Domain.Entities
{
  public  class ProductProperty : TenantBase
    {
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
        public string Value { get; set; }
    }
}
