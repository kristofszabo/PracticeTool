using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models.Components;

namespace PracticeTool.Models {
    class VoicePlayerComponent : UrlComponent {
        public VoicePlayerComponent(Component component, string url) : base(component)
        {
            Url = url;
        }
    }
}
