namespace VacuumeSimulator
{
    public class Carpet : Cell, ICleanable
    {
        public override CellType Type { get { return CellType.Carpet; } }

        public bool IsDirty { get; private set; }
        
        public Carpet(Position position, bool isDerty)
            : base(position)
        {
            IsDirty = isDerty;
        }

        public override void Move(Battery battery)
        {
            battery.Reduce(1);
        }

        public void Clean(Battery battery)
        {
            if (!IsDirty)
                return;

            battery.Reduce(2);
            IsDirty = false;
        }
    }
}