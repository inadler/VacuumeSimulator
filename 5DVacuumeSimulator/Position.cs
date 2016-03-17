using System;

namespace VacuumeSimulator
{
    public struct Position : IEquatable<Position>
    {
        public int X;
        public int Y;

        public Position(int y, int x)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override string ToString()
        {
            return string.Format("{0},{1}",Y, X);        
        }
    }
}