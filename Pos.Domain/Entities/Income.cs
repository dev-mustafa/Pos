using System;
using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class Income : TenantBase
    {
        public Income()
        {
            Installments = new List<Installment>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Installment> Installments { get; set; }
    }
}
