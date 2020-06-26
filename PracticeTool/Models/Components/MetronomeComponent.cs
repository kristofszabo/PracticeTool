using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models.Components;

namespace PracticeTool.Models {
    class MetronomeComponent : SecondsComponent {
        
        

        public MetronomeComponent(Component component, int? seconds): base(component, (int)seconds)
        {
            
        }

        
    }
}
