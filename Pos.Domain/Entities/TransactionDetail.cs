using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Domain.Entities
{
    public class TransactionDetail : TenantBase
    {
        public TransactionDetail()
        {
            Barcodes = new List<TransactionDetailBarcode>();
        }
        public int Id { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        [NotMapped]
        public double Total => Amount * Price;

        public int ProductId { get; set; }
        public int TransactionId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual ICollection<TransactionDetailBarcode> Barcodes { get; set; }
    }

}
