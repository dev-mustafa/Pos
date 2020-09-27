using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class Machine : EntityBase
    {
        public Machine()
        {
            Shifts = new List<Shift>();
        }

        public string Name { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        
    }
}