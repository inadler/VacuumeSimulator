namespace VacuumeSimulator
{
   
    public class Floor : Cell, ICleanable
    {
        public override CellType Type { get { return CellType.Floor; } }

        public bool IsDirty { get; private set; }
        
        public Floor(Position position, bool isDerty)
            :base(position)
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

            battery.Reduce(1);
            IsDirty = false;
        }        
    }
}