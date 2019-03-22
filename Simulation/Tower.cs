using System.Collections.Generic;
using System.Linq;

namespace AircraftSimulation.Simulation
{
    public class Tower
    {
        private List<Flyable> Observers = new List<Flyable>();

        public void Register(Flyable flyable)
        {
            Observers.Add(flyable);
        }

        public void Unregister(Flyable flyable)
        {
            Observers.Remove(flyable);
        }

        protected void ConditionsChanged()
        {
            for (int i = 0; i < Observers.Count(); i++)
            {
                Observers[i].UpdateConditions();
            }
        }
    }
}
