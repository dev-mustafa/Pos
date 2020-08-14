using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Domain.Entities
{
   public  class CategoryProperty : TenantBase
    {
        public int CategoryId { get; set; }
        public int PropertyId { get; set; }
    }
}
