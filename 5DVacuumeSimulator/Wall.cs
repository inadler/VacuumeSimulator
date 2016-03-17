namespace VacuumeSimulator
{    
    public class Wall : Cell
    {
        public override void Move(Battery battery) { }

        public override CellType Type { get { return CellType.Wall; } }

        public Wall(Position position)
            : base(position)
        {            
        }
    }
}