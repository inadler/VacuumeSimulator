namespace VacuumeSimulator
{
    public class DockStation : Cell
    {
        public override CellType Type { get { return CellType.DockStation; } }
        

        public DockStation(Position position)
            : base(position)
        {            
        }

        public override void Move(Battery battery)
        {
            battery.Reduce(1);
        }
    }
}