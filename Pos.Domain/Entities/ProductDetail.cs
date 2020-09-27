namespace Pos.Domain.Entities
{
   public class ProductDetail : EntityBase
    {

        public double Amount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
