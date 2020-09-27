﻿namespace Pos.Domain.Entities
{
    public class TransactionDetailBarcode : EntityBase
    {

        public int BarCodeId { get; set; }
        public int TransactionDetailId { get; set; }
        public virtual BarCode BarCode { get; set; }    
        public virtual TransactionDetail TransactionDetail { get; set; }

    }  

}
