using System;

namespace VacuumeSimulator
{
    class Program
    {
        public static void Main()
        {
            var fileReader = new FileReader(@"map.txt");
            var sensor = new Sensor(fileReader);

            sensor.Print();

            var robot = new Robot(sensor);
            try
            {
                robot.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            

            Console.WriteLine("Battery moves: {0}", robot.GetBatteryMoves());

            sensor.Print();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}