using System;
using System.Collections.Generic;
using System.Linq;
namespace AircraftSimulation.Simulation
{
    public class Aircraft
    {
        protected long Id;
        protected string Name;
        protected Coordinates Coordinates;
        private static long IdCounter = 1;

        protected Aircraft(string name, Coordinates coordinates)
        {
            Name = name;
            Coordinates = coordinates;
            Id = NextId();
        }

        private long NextId()
        {
            //Return a unique id
            return (IdCounter++);
        }
    }
}
