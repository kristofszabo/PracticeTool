using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Creators {
    class PausableTimerComponentCreator : IComponentCreator {


        public Component GetInstantiate(Component component, string url, string description, int? seconds)
        {
            return new PausableTimerComponent(component, seconds);
        }
    }
}
