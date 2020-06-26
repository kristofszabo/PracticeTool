using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models;

namespace TPHDatabase.Creators {
    interface IComponentCreator {
        public Component GetInstantiate(Component component, string? url, string? description, int? seconds);
    }
}
