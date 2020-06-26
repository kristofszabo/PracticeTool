using System;
using System.Collections.Generic;
using System.Text;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Models {
    class PdfReaderComponent : UrlComponent {
        public PdfReaderComponent(Component component, string url) : base(component)
        {
            Url = url;
        }
    }
}
