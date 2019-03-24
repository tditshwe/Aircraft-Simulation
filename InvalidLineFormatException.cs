using System;

namespace AircraftSimulation
{
    public class InvalidLineFormatException: Exception
    {
        public InvalidLineFormatException(string message):base("Airplane description error: " + message) { }
    }
}
