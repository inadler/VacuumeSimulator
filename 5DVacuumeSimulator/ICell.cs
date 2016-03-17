using System;

namespace VacuumeSimulator
{
    public interface ICell : IEquatable<ICell>
    {        
        Position Position { get; }
        void Move(Battery battery);
        CellType Type { get; }        
    }

    public abstract class Cell : ICell
    {
        public Position Position { get; private set; }

        public abstract CellType Type { get; }

        protected Cell(Position position)
        {
            Position = position;
        }

        public abstract void Move(Battery battery);
        
        public bool Equals(ICell other)
        {
            return Position.Equals(other.Position);
        }
    }
}