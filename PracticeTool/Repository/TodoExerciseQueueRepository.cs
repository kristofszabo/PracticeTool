﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Repository {
    class TodoExerciseQueueRepository : AdoRepository<TodoExerciseQueue> {
        public TodoExerciseQueueRepository(string connectionString) : base(connectionString)
        {
        }

        public override TodoExerciseQueue PopulateRecord(DbDataReader reader)
        {
            var id = reader.GetInt32("Id");
            var time = reader.GetInt32("time");
            var isFinished = reader.GetInt32("isFinished");

            return new TodoExerciseQueue(id, time, isFinished);
        }

        public IQueryable<TodoExerciseQueue> GetAll()
        {
            var command = new SqliteCommand(
                "SELECT * FROM TodoExerciseQueue");
            return GetRecords(command);
        }

        public TodoExerciseQueue GetById(string id)
        {
            var command = new SqliteCommand(
                "SELECT * FROM TodoExerciseQueue " +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("id", id));
            return GetRecord(command);
        }

        public void Delete(string id)
        {
            var command = new SqliteCommand(
                "DELETE TodoExerciseQueue" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("id", id));
        }

        public void Update(TodoExerciseQueue todoExerciseQueue)
        {
            var command = new SqliteCommand(
                "UPDATE TodoExerciseQueue" +
                "SET IsFinished=@isFinished, Time = @time " +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("isFinished", todoExerciseQueue.IsFinished));
            command.Parameters.Add(new SqliteParameter("id", todoExerciseQueue.Id));
            command.Parameters.Add(new SqliteParameter("time", todoExerciseQueue.Time));

        }

        public void Insert(TodoExerciseQueue todoExerciseQueue)
        {
            var commandCreate = new SqliteCommand(
                "INSERT INTO TodoExerciseQueue(IsFinished, Time)" +
                "VALUES (@isFinished, @time)");
            commandCreate.Parameters.Add(new SqliteParameter("isFinished", todoExerciseQueue.IsFinished));

            
        }
    }
}
