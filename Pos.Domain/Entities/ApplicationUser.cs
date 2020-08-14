using Microsoft.AspNetCore.Identity;

namespace Pos.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            TenantId = TenantContext.TenantId;
        }
        public int TenantId { get; set; }
    }

}
