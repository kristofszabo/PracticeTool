using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models;
using PracticeTool.Models.Components;

namespace PracticeTool.Creators {
    class DescriptionComponentCreator : IComponentCreator {
        

        Component IComponentCreator.GetInstantiate(Component component, string url, string description, int? seconds)
        {
            return new DescriptionComponent(component, description);
        }
    }
}
