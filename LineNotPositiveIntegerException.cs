using System;

namespace AircraftSimulation
{
    public class LineNotPositiveIntegerException: Exception
    {
        public LineNotPositiveIntegerException(string message): base(message) { }
    }
}
