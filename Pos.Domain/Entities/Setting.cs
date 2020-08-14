namespace Pos.Domain.Entities
{
    public class Setting : TenantBase
    {
        public int Id { get; set; }
        public double StartBalance { get; set; }
        public bool HasMachines { get; set; }
        public bool HasShifts { get; set; }

    }
}
