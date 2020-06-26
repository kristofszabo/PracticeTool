using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Repository {
    class ExerciseQueueRepository : AdoRepository<ExerciseQueue> {
        public ExerciseQueueRepository(string connectionString) : base(connectionString)
        {
        }

        public override ExerciseQueue PopulateRecord(DbDataReader reader)
        {
            var id = reader.GetInt32("Id");
            var name = reader.GetString("Name");
            return new ExerciseQueue(id, name);

        }


        public IQueryable<ExerciseQueue> GetAll()
        {
            var command = new SqliteCommand(
                "SELECT * FROM ExerciseQueue");
            return GetRecords(command);
        }

        public ExerciseQueue GetById(string id)
        {
            var command = new SqliteCommand(
                "SELECT * FROM ExerciseQueue" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("id", id));
            return GetRecord(command);
        }

        public void Insert(ExerciseQueue exerciseQueue)
        {
            var command = new SqliteCommand(
                "INSERT INTO ExerciseQueue(Name)" +
                "VALUES(@name)");
            command.Parameters.Add(new SqliteParameter("name", exerciseQueue.Name));
        }

        public void Delete(ExerciseQueue exerciseQueue)
        {
            var command = new SqliteCommand(
                "DELETE ExerciseQueue" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("id", exerciseQueue.Id));
            Execute(command);
        }

        public void Update(ExerciseQueue exerciseQueue)
        {
            var command = new SqliteCommand(
                "UPDATE ExerciseQueue" +
                "SET Name = @name");
            command.Parameters.Add(new SqliteParameter("name", exerciseQueue.Name));
            Execute(command);
        }
    }
}
