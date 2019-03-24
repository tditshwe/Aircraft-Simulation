namespace AircraftSimulation.Simulation
{
    public class AircraftFactory
    {
        public Flyable NewAircraft(string type, string name, int longitude, int latitude, int height)
        {
            Coordinates coordinates = new Coordinates(longitude, latitude, height);
            Flyable flyable = null;

            if (type == "Helicopter")
                flyable = new Helicopter(name, coordinates);
            else if (type == "JetPlane")
                flyable = new JetPlane(name, coordinates);
            else if (type == "Baloon")
                flyable = new Baloon(name, coordinates);

            return flyable;
        }
    }
}
