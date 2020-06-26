using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Creators {
    class DescriptionComponentCreator : IComponentCreator {
        

        Component IComponentCreator.GetInstantiate(Component component, string url, string description, int? seconds)
        {
            return new DescriptionComponent(component, description);
        }
    }
}
