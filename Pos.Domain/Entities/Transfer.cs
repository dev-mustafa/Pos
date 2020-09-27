using System.Collections.Generic;

namespace Pos.Domain.Entities
{

   public class Transfer : EntityBase
    {
        public Transfer()
        {
            TransfareDetails = new List<TransferDetail>();
        }

        public int FromPointId { get; set; }
        public virtual Point FromPoint { get; set; }
        public int ToPointId { get; set; }
        public virtual Point ToPoint { get; set; }
        public virtual ICollection<TransferDetail> TransfareDetails { get; set; }
    }

}
