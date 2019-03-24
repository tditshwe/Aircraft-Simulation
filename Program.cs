using System;
using AircraftSimulation.Simulation;
using System.IO;

namespace AircraftSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator simulation = Simulator.GetInstance();
            ScenarioFileReader sceneReader = null;

            try
            {
                sceneReader = new ScenarioFileReader("scenario.txt");

                simulation.InitWriter();
                sceneReader.Read();
                WeatherTower wTower = sceneReader.WeatherTower;
                int triggers = sceneReader.Triggers;

                simulation.AppendNewLine();

                for (int i = 0; i < triggers; i++)
                {
                    wTower.ChangeWeather();
                    simulation.AppendNewLine();
                }

                Console.WriteLine("Simulation file successfully generated");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (LineNotPositiveIntegerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidLineFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sceneReader != null)
                    sceneReader.Close();

                simulation.CloseWriter();
                Console.Write("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
