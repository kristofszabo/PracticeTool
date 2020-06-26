using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Models {
    class VideoComponent : UrlComponent {
        public VideoComponent(Component component, string url) : base(component)
        {
            Url = url;
        }
    }
}
