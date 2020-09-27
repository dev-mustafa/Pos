using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Pos.Domain.Enums;

namespace Pos.Domain.Entities
{
    public class Transaction : EntityBase
    {
        public Transaction()
        {
            Details = new List<TransactionDetail>();
            TransactionBacks = new List<Transaction>();
            Installments = new List<Installment>();
            Cheques = new List<Cheque>();
        }

        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double Paid { get; set; }
        public double Discount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TransactionType TransactionType { get; set; }
        public int PersonId { get; set; }
        public int PointId { get; set; }
        public int ShiftId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Point Point { get; set; }
        public virtual Shift Shift { get; set; }    
        public virtual BankTransaction BankTransaction { get; set; }
        public virtual ICollection<TransactionDetail> Details { get; set; }
        public virtual ICollection<Transaction> TransactionBacks { get; set; }
        public virtual ICollection<Installment> Installments { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
        [NotMapped]
        public double Total => Details.Sum(s => s.Total);
    }
}
