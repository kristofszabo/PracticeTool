using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTool.Models {
    public class Exercise {

        public Exercise()
        {

        }
        public Exercise(long id, string name, long created)
        {
            Id = id;
            Name = name;
            Created = created;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Created { get; set; }
    }
}
