using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Domain.Entities
{
    public class Stock : TenantBase
    {
        public int ProductId { get; set; }
        public int PointId { get; set; }
        public double Amount { get; set; }
        public Product Product { get; set; }
        public Point Point { get; set; }
    }
}
