namespace Pos.Domain.Entities
{
    public class DamagedDetail : ProductDetail
    {
        public int DamagedId { get; set; }
        public virtual Damaged Damaged { get; set; }

    }
}