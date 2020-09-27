using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Domain.Entities
{
   public  class CategoryProperty : TenantBase
    {
        public int CategoryId { get; set; }
        public int PropertyId { get; set; }
    }
}
