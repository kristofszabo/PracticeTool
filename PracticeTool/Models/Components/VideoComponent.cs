using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models.Components;

namespace PracticeTool.Models {
    class VideoComponent : UrlComponent {
        public VideoComponent(Component component, string url) : base(component)
        {
            Url = url;
        }
    }
}
