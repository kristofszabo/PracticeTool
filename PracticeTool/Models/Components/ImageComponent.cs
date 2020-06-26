using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models.Components;

namespace PracticeTool.Models {
    class ImageComponent : UrlComponent {
        private Component component;

        public ImageComponent(Component component, string url) : base(component)
        {
            this.component = component;
            Url = url;
        }


        
    }
}
