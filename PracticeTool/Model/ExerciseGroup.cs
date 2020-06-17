using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTool.Model {
    public class ExerciseGroup {
		private String name;

		public String Name {
			get { return name; }
			set { name = value; }
		}

		


		public List<Exercise> MyProperty {
			get { return exercises; }
			set { exercises = value; }
		}


	}
}
