using System;

namespace AircraftSimulation.Simulation
{
    public class WeatherProvider
    {
        private static WeatherProvider _WeatherProvider = new WeatherProvider();
        //Four types of weather
        private static string[] Weather = { "RAIN", "SUN", "FOG", "SNOW" };

        private WeatherProvider() { }

        public static WeatherProvider GetProvider()
        {
            return _WeatherProvider;
        }

        public string GetCurrentWeather(Coordinates coordinates)
        {
            Random rand = new Random();
            //Some random algorithm to generate weather
            int weatherStatus = rand.Next(coordinates.Latitude * 3 + coordinates.Longitude * 5 + coordinates.Height) + 4;

            return Weather[weatherStatus % 4];
        }
    }
}
