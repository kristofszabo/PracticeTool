using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Models {
    class ImageComponent : UrlComponent {
        private Component component;

        public ImageComponent(Component component, string url) : base(component)
        {
            this.component = component;
            Url = url;
        }


        
    }
}
