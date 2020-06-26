using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models.Components;

namespace PracticeTool.Models {
    class PdfReaderComponent : UrlComponent {
        public PdfReaderComponent(Component component, string url) : base(component)
        {
            Url = url;
        }
    }
}
