using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTool.Models {
    class ExerciseExerciseQueueConn {
        

        public ExerciseExerciseQueueConn(string id, int exerciseId, int exerciseQueueId)
        {
            this.Id = id;
            this.ExerciseId = exerciseId;
            this.ExerciseQueueId = exerciseQueueId;
        }

        public string Id { get; private set; }
        public int ExerciseId { get; private set; }
        public int ExerciseQueueId { get; private set; }
    }
}
