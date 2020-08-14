﻿using System.Collections.Generic;

namespace Pos.Domain.Entities
{
    public class BarCode : TenantBase
    {
        public BarCode()
        {
            Details = new List<TransactionDetailBarcode>();
        }
        public int Id { get; set; }
        public string Barcode { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<TransactionDetailBarcode> Details { get; set; }

    }
}
