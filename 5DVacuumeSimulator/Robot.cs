using System;
using System.Collections.Generic;

namespace VacuumeSimulator
{
    class Robot
    {        
        private readonly IList<ICell> Visited = new List<ICell>();

        public Random _random = new Random();
        private readonly Battery _battery = new Battery();
        private readonly Sensor _sensor;      

        public Robot(Sensor sensor)
        {
            _sensor = sensor;
        }

        public void Start()
        {
            // assuming the robot is in the docking station;
            var startingPoint = _sensor.Start();
            Move(_sensor.LookDown(startingPoint));       
        }


        public void Move(ICell cell)
        {
            Console.WriteLine("{0} - {1}", cell.Position, cell.Type);
            Visited.Add(cell);
            
            if (cell.Type == CellType.Wall)
                return;

            cell.Move(_battery); // consume the battery

            if (cell.Type == CellType.DockStation)
                _battery.Reset(); // reset battery level
            else
                ((ICleanable) cell).Clean(_battery); // consume the battery if 

            if (_battery.IsGettingLow())
                return;


            var nextCell = _sensor.LookUP(cell);
            if (!Visited.Contains(nextCell))
                Move(nextCell);
            
            nextCell = _sensor.LookDown(cell);
            if (!Visited.Contains(nextCell))
                Move(nextCell);

            nextCell = _sensor.LookLeft(cell);
            if (!Visited.Contains(nextCell))
                Move(nextCell);

            nextCell = _sensor.LookRight(cell);
            if (!Visited.Contains(nextCell))
                Move(nextCell);
            

            cell.Move(_battery); // consume the battery

            if (cell.Type == CellType.DockStation)
                _battery.Reset(); // reset battery level

        }


        public int GetBatteryMoves()
        {
            return _battery.Moves;
        }
    }
}
