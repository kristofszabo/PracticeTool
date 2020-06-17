using PracticeTool.HelperClass;
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



		private UniqueList<Exercise> exercises;

		public UniqueList<Exercise> Exercises {
			get { return exercises; }
		}
		


	}
}
