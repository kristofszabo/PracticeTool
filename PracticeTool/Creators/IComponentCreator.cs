using System;
using System.Collections.Generic;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Creators {
    interface IComponentCreator {
        public Component GetInstantiate(Component component, string? url, string? description, int? seconds);
    }
}
