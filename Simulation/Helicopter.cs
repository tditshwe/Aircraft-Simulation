namespace AircraftSimulation.Simulation
{
    public class Helicopter: Aircraft, Flyable
    {
        private WeatherTower WeatherTower;
        Simulator Simulation;

        Helicopter(string name, Coordinates coordinates): base(name, coordinates)
        {
            Simulation = Simulator.GetInstance();
        }

        public void UpdateConditions()
        {
            string weather = WeatherTower.GetWeather(Coordinates);

            Simulation.UpdateConditions("Helicopter", Name, Id);

            //Manipulate aircraft longitude, latitude and height depending on weather
            switch (weather)
            {
                case "SUN":
                    Coordinates = new Coordinates(Coordinates.Longitude + 10,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height + 2));
                    Simulation.UpdateConditions("It's just the sun shining.");
                break;
                case "RAIN":
                    Coordinates = new Coordinates(Coordinates.Longitude + 5,
                        Coordinates.Latitude, Coordinates.Height);
                    Simulation.UpdateConditions("Mid air sucks in the rain.");
                    break;
                case "FOG":
                    Coordinates = new Coordinates(Coordinates.Longitude + 1,
                        Coordinates.Latitude, Coordinates.Height);
                    Simulation.UpdateConditions("Only the boogeyman hovers in this fog.");
                break;
                case "SNOW":
                    Coordinates = new Coordinates(Coordinates.Longitude,
                        Coordinates.Latitude, Simulation.ValidHeight(Coordinates.Height - 12));
                    Simulation.UpdateConditions("The snow men can't touch me up here");
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
            Simulation.RegisterAircraft("Helicopter", Name, Id);
            WeatherTower = weatherTower;
        }
    }
}
