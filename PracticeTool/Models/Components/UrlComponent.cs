using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTool.Models.Components {
    class UrlComponent : Component {
        public UrlComponent(Component component): base(component)
        {

        }

        public string Url { get; set; }
    }
}
