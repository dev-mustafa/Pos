using System.Collections.Generic;
using Pos.Domain.Enums;

namespace Pos.Domain.Entities
{
    public class Person : EntityBase
    {
        public Person()
        {
            Transactions = new List<Transaction>();
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
        public PersonType PersonType { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
