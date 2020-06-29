using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTool.Models {
    public class ComponentType {
        public ComponentType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
