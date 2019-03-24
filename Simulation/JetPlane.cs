namespace AircraftSimulation.Simulation
{
    public class JetPlane: Aircraft, Flyable
    {
        private WeatherTower WeatherTower;
        Simulator Simulation;

        internal JetPlane(string name, Coordinates coordinates) : base(name, coordinates)
        {
            Simulation = Simulator.GetInstance();
        }

        public void UpdateConditions()
        {
            string weather = WeatherTower.GetWeather(Coordinates);

            Simulation.UpdateConditions("JetPlane", Name, Id);

            //Manipulate aircraft longitude, latitude and height depending on weather
            switch (weather)
            {
                case "SUN":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude + 10, Simulation.ValidHeight(Coordinates.Height + 2));
                    Simulation.UpdateConditions("This son is boring.");
                break;
                case "RAIN":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude + 5, Coordinates.Height);
                    Simulation.UpdateConditions("I'm too fast for the rain drops.");
                break;
                case "FOG":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude + 1, Coordinates.Height);
                    Simulation.UpdateConditions("This fog is nothing compared to my engine steam.");
                break;
                case "SNOW":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height - 7));
                    Simulation.UpdateConditions("Don't take part in snow fight while I'm flying.");
                break;
            }

            //Aircraft landing
            if (Coordinates.Height == 0)
            {
                Simulation.UnregisterAircraft("JetPlane", Name, Id);
                WeatherTower.Unregister(this);
            }
        }

        public void RegisterTower(WeatherTower weatherTower)
        {
            Simulation.RegisterAircraft("JetPlane", Name, Id);
            WeatherTower = weatherTower;
        }
    }
}
