﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TPHDatabase.Models.Components {
    class SecondsComponent : Component{

        public SecondsComponent(Component component,int seconds) :base(component)
        {
            Seconds = seconds;
        }

        public int Seconds { get; set; }
    }
}
