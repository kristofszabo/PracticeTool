using System;
using System.Collections.Generic;
using System.Text;

namespace TPHDatabase.Models {
    public class Component {
        private int compTypeId;

        public Component(Component component)
        {
            Id = component.Id;
            Name = component.Name;
            ExerciseId = component.ExerciseId;
            Placement = component.Placement;
            ComponentTypeId = component.ComponentTypeId;
        }

        public Component(int id, string name, int placement, int exerciseId, int compTypeId)
        {
            Id = id;
            Name = name;
            Placement = placement;
            ExerciseId = exerciseId;
            this.compTypeId = compTypeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseId { get; set; }
        public int Placement { get; set; }
        public int ComponentTypeId { get; set; }

    }
}
