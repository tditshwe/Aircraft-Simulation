namespace AircraftSimulation.Simulation
{
    public class Coordinates
    {
        private int _Longitude;
        private int _Latitude;
        private int _Height;

        internal Coordinates(int longitude, int latitude, int height)
        {
            _Longitude = longitude;
            _Latitude = latitude;
            _Height = height;
        }

        public int Longitude
        {
            get
            {
                return _Longitude;
            }
        }

        public int Latitude
        {
            get
            {
                return _Latitude;
            }
        }

        public int Height
        {
            get
            {
                return _Height;
            }
        }
    }
}
