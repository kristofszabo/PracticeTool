using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models;

namespace TPHDatabase.Creators {
    class PausableTimerComponentCreator : IComponentCreator {


        public Component GetInstantiate(Component component, string url, string description, int? seconds)
        {
            return new PausableTimerComponent(component, seconds);
        }
    }
}
