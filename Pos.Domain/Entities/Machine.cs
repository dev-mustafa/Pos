﻿using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class Machine : TenantBase
    {
        public Machine()
        {
            Shifts = new List<Shift>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        
    }
}