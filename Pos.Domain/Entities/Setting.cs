namespace Pos.Domain.Entities
{
    public class Setting : EntityBase
    {

        public double StartBalance { get; set; }
        public bool HasMachines { get; set; }
        public bool HasShifts { get; set; }

    }
}
