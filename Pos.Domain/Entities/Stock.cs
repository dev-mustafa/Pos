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
