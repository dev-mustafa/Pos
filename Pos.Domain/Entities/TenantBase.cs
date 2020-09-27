using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Domain.Entities
{
    public class TenantBase
    {
        public int TenantId { get; set; }

        public TenantBase()
        {
            TenantId = TenantContext.TenantId;
        }
    }
    public class EntityBase : TenantBase
    {

        public int Id { get; set; }

    }
}
