using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Repository {
    class ExerciseExerciseQueueConnRepository : AdoRepository<ExerciseExerciseQueueConn> {
        public ExerciseExerciseQueueConnRepository(string connectionString) : base(connectionString)
        {
        }

        public override ExerciseExerciseQueueConn PopulateRecord(DbDataReader reader)
        {
            var id = reader.GetString("Id");
            var exerciseId = reader.GetInt32("ExerciseId");
            var exerciseQueueId = reader.GetInt32("ExerciseQueueId");

            return new ExerciseExerciseQueueConn(id, exerciseId, exerciseQueueId);
        }

        public void Insert(Exercise exercise, ExerciseQueue exerciseQueue)
        {
            var command = new SqliteCommand(
                "INSERT INTO ExerciseExerciseQueueConn (ExerciseId, ExerciseQueueId)" +
                "VALUES (@exerciseId, @exerciseQueueId)");
            command.Parameters.Add(new SqliteParameter("exerciseId", exercise.Id));
            command.Parameters.Add(new SqliteParameter("exerciseQueueId", exerciseQueue.Id));
            Execute(command);

        }
        public void Delete(Exercise exercise, ExerciseQueue exerciseQueue)
        {
            var command = new SqliteCommand(
                "DELETE ExerciseExerciseQueueConn" +
                "WHERE ExerciseId = @exerciseId " +
                "AND ExerciseQueueId = @exerciseQueueId");
            command.Parameters.Add(new SqliteParameter("exerciseId", exercise.Id));
            command.Parameters.Add(new SqliteParameter("exerciseQueueId", exerciseQueue.Id));
            Execute(command);

        }


    }
}
