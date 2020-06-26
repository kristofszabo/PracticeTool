using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models.Components;

namespace PracticeTool.Models {
    class PausableTimerComponent : SecondsComponent {
        

        public PausableTimerComponent(Component component, int? seconds):base(component,(int)seconds)
        {

        }

    }
}
