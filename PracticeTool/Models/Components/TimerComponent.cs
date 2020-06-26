using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Models {
    class TimerComponent : SecondsComponent {
        

        public TimerComponent(Component component, int? seconds) : base(component,(int)seconds)
        {
            
        }
    }
}
