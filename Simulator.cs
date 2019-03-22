using System;
using System.IO;

namespace AircraftSimulation
{
    /*
     * Singleton Class
     */
    public class Simulator
    {
        private StreamWriter Writer;
        private static readonly Simulator Instance = new Simulator();

        //Restricts the instantiation of Simulator
        private Simulator() { }

        //Give access to Simulator instAnce
        public static Simulator GetInstance()
        {
            return Instance;
        }

        public void InitWriter()
        {
            try
            {
                Writer = new StreamWriter("simulation.txt");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RegisterAircraft(string type, string name, long id)
        {
            Writer.WriteLine("Tower says: " + type + "#" + name + "(" + id + ") registered to weather tower");
        }

        public void UnregisterAircraft(string type, string name, long id)
        {
            Writer.WriteLine(type + "#" + name + "(" + id + ") landing.");
            Writer.WriteLine("Tower says: " + type + "#" + name + "(" + id + ") unregistered from weather tower");
        }

        public void UpdateConditions(string type, string name, long id)
        {
            Writer.Write(type + "#" + name + "(" + id + "): ");
        }

        public void UpdateConditions(string message)
        {
            Writer.WriteLine(message);
        }

        /*
         * Only accept height greater than 0 and less than 100
         */
        public int ValidHeight(int height)
        {
            if (height > 100)
                return 100;
            if (height < 0)
                return 0;

            return height;
        }

        public void AppendNewLine()
        {
            Writer.WriteLine();
        }

        public void CloseWriter()
        {

            if (Writer != null)
                Writer.Close();
        }
    }
}
