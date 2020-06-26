using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Models {
    class VoicePlayerComponent : UrlComponent {
        public VoicePlayerComponent(Component component, string url) : base(component)
        {
            Url = url;
        }
    }
}
