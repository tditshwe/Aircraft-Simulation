namespace AircraftSimulation.Simulation
{
    public class Baloon: Aircraft, Flyable
    {
        private WeatherTower WeatherTower;
        Simulator Simulation;

        Baloon(string name, Coordinates coordinates) : base(name, coordinates)
        {
            Simulation = Simulator.GetInstance();
        }

        public void UpdateConditions()
        {
            string weather = WeatherTower.GetWeather(Coordinates);

            Simulation.UpdateConditions("Baloon", Name, Id);

            //Manipulate aircraft longitude, latitude and height depending on weather
            switch (weather)
            {
                case "SUN":
                    Coordinates = new Coordinates(Coordinates.Longitude + 2,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height + 4));
                    Simulation.UpdateConditions("I shall not be favoured by hotness.");
                break;
                case "RAIN":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height - 5));
                    Simulation.UpdateConditions("How can these rain drops take mee down.");
                    break;
                case "FOG":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height - 3));
                    Simulation.UpdateConditions("This messy fog makes floating easy.");
                break;
                case "SNOW":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height - 15));
                    Simulation.UpdateConditions("Even baloons can freeze to death.");
                break;
            }

            //Aircraft landing
            if (Coordinates.Height == 0)
            {
                Simulation.UnregisterAircraft("Helicopter", Name, Id);
                WeatherTower.Unregister(this);
            }
        }

        public void RegisterTower(WeatherTower weatherTower)
        {
            Simulation.RegisterAircraft("Baloon", Name, Id);
            WeatherTower = weatherTower;
        }
    }
}
