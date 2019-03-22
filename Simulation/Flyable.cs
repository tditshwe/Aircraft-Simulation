namespace AircraftSimulation.Simulation
{
    public interface Flyable
    {
        void UpdateConditions();
        void RegisterTower(WeatherTower weatherTower);
    }
}
