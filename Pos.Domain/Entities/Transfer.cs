using System.Collections.Generic;

namespace Pos.Domain.Entities
{

   public class Transfer : TenantBase
    {
        public Transfer()
        {
            TransfareDetails = new List<TransferDetail>();
        }
        public int Id { get; set; }
        public int FromPointId { get; set; }
        public virtual Point FromPoint { get; set; }
        public int ToPointId { get; set; }
        public virtual Point ToPoint { get; set; }
        public virtual ICollection<TransferDetail> TransfareDetails { get; set; }
    }

}
