﻿using System;
using Pos.Domain.Enums;

namespace Pos.Domain.Entities
{
    public class Installment : TenantBase
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int IncomeId { get; set; }

        public Income Income { get; set; }

        public int? ShiftId { get; set; }

        public virtual Shift Shift { get; set; }
        public int TransactionId { get; set; }

        public virtual Transaction Transaction { get; set; }

    }
}
