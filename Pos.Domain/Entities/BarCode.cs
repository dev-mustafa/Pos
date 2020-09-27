using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class BarCode : EntityBase
    {
        public BarCode()
        {
            Details = new List<TransactionDetailBarcode>();
        }

        public string Barcode { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<TransactionDetailBarcode> Details { get; set; }

    }
}
