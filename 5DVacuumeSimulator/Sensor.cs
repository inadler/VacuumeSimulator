using System;
using System.Collections.Generic;

namespace VacuumeSimulator
{
    public class Sensor
    {
        private readonly List<List<ICell>> _map;

        public Sensor(IMapReader mapReader)
        {
            _map = mapReader.Read();
        }

        public void Print()
        {
            for (int y = 0; y < _map.Count; y++)
            {
                List<ICell> row = _map[y];
                Console.Write(" {0}", y);

                for (int x = 0; x < row.Count; x++)
                {
                    ICell coll = row[x];
                    switch (coll.Type)
                    {
                        case CellType.DockStation:
                            Console.Write(" D ");
                            break;
                        case CellType.Floor:
                            Console.Write(((ICleanable) coll).IsDirty ? "F-x" : "F-o");
                            break;
                        case CellType.Wall:
                            Console.Write(" W ");
                            break;
                        case CellType.Carpet:
                            Console.Write(((ICleanable) coll).IsDirty ? "C-x" : "C-o");
                            break;
                    }
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        public ICell Start()
        {
            return _map[1][1];
        }

        public bool IsWall(ICell cell)
        {
            return cell.Type == CellType.Wall;
        }

        public ICell LookUP(ICell cell)
        {
            return _map[cell.Position.Y - 1][cell.Position.X];
        }

        public ICell LookDown(ICell cell)
        {
            return _map[cell.Position.Y + 1][cell.Position.X];
        }

        public ICell LookLeft(ICell cell)
        {
            return _map[cell.Position.Y][cell.Position.X - 1];
        }

        public ICell LookRight(ICell cell)
        {
            return _map[cell.Position.Y][cell.Position.X + 1];
        }
    }
}