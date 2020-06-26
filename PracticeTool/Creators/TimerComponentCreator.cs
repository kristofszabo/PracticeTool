﻿using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Creators {
    class TimerComponentCreator : IComponentCreator {
        public Component GetInstantiate(Component component, string url, string description, int? seconds)
        {
            return new TimerComponent(component, seconds);
        }
    }
}
