using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Domain.Entities
{
   public  class TenantBase
    {
        public TenantBase()
        {
            TenantId = TenantContext.TenantId;
        }
        public int TenantId { get; set; }
    }
}
