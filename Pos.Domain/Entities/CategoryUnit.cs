﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Domain.Entities
{
 public  class CategoryUnit : TenantBase
    {
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
    }
}
