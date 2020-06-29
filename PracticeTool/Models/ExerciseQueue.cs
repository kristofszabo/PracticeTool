using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTool.Models {
    public class ExerciseQueue {
        public ExerciseQueue(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
