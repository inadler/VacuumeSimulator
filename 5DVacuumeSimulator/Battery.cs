using System;

namespace VacuumeSimulator
{
    public class Battery
    {
        private const int StartingSize = 200;

        public int Moves { get; private set; }
        public decimal Size { get; private set; }

        public Battery()
        {
            Moves = 0;
            Reset();
        }

        public void Reset()
        {
            Size = StartingSize;
        }

        public bool IsGettingLow()
        {
            if (Size == 0)
                throw new Exception("Battery is dead !!!");

            return Size / StartingSize * 100 <= 20;
        }

        public void Reduce(int val)
        {
            Size -= val;

            Moves += val;

            if (Size == 0)
                throw new Exception("Battery is dead !!!");
        }      
    }
}