using System;
using System.Collections.Generic;
using System.IO;

namespace VacuumeSimulator
{
    class FileReader : IMapReader
    {
        private readonly string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<List<ICell>> Read()
        {            
            var lines = File.ReadAllLines(_filePath);

            var map = new List<List<ICell>>(lines.Length);
            for (int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                var row = new List<ICell>(line.Length);

                for (int x = 0; x < line.Length; x++)
                {
                    var position = new Position(y, x);

                    var cell = line[x];
                    switch (cell)
                    {
                        case 'w':
                            row.Add(new Wall(position));
                            break;

                        case 'f':
                            row.Add(new Floor(position, false));
                            break;
                        case 'F':
                            row.Add(new Floor(position, true));
                            break;

                        case 'c':
                            row.Add(new Carpet(position, false));
                            break;
                        case 'C':
                            row.Add(new Carpet(position, true));
                            break;

                        case 'D':
                            row.Add(new DockStation(position));
                            break;

                        default:
                            throw new NotSupportedException(string.Format("{0} is not supported", cell));
                    }
                }

                map.Add(row);
            }

            return map;
        }
    }
}