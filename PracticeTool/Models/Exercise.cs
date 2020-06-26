using System;
using System.Collections.Generic;
using System.Text;

namespace TPHDatabase.Models {
    class Exercise {
        public Exercise(int id, string name, int created)
        {
            Id = id;
            Name = name;
            Created = created;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Created { get; set; }
    }
}
