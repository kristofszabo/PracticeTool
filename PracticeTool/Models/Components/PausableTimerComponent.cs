using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Models {
    class PausableTimerComponent : SecondsComponent {
        

        public PausableTimerComponent(Component component, int? seconds):base(component,(int)seconds)
        {

        }

    }
}
