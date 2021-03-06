﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTool.Models {
    public class TodoExerciseQueue {
        public TodoExerciseQueue(int id, int time, int isFinished)
        {
            Id = id;
            Time = time;
            IsFinished = isFinished;
        }

        public int Id { get; set; }
        public int Time { get; set; }
        public int IsFinished { get; set; }
    }
}
