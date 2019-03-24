namespace AircraftSimulation.Simulation
{
    public class WeatherTower: Tower
    {
        public string GetWeather(Coordinates coordinates)
        {
            WeatherProvider provider = WeatherProvider.GetProvider();

            return provider.GetCurrentWeather(coordinates);
        }

        public void ChangeWeather()
        {
            ConditionsChanged();
        }
    }
}
