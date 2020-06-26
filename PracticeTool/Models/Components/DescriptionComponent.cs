using System;
using System.Collections.Generic;
using System.Text;

namespace TPHDatabase.Models.Components {
    class DescriptionComponent : Component{
        public DescriptionComponent(Component component, string description) : base(component)
        {
            Description = description;
            
        }

        public string Description { get; set; }
    }
}
