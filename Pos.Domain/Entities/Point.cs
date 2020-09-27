using Pos.Domain.Enums;
using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class Point : EntityBase
    {
        public Point()
        {
            Transactions = new List<Transaction>();
            OutTransfares = new List<Transfer>();
            InTransfares = new List<Transfer>();
            Damageds = new List<Damaged>();
            Stocks = new List<Stock>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public PointType PointType { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Transfer> InTransfares { get; set; }
        public ICollection<Transfer> OutTransfares { get; set; }
        public ICollection<Damaged> Damageds { get; set; }
        public ICollection<Stock> Stocks { get; set; }

    }
}
