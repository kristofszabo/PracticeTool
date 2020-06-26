using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using TPHDatabase.Models;

namespace TPHDatabase.Repository {
    class ExerciseRepository : AdoRepository<Exercise> {
        public ExerciseRepository(string connectionString) : base(connectionString)
        {
        }

        public override Exercise PopulateRecord(DbDataReader reader)
        {
            var id = reader.GetInt32("Id");
            var name = reader.GetString("Name");
            var created = reader.GetInt32("Created");

            return new Exercise(id, name, created);

        }

        public IQueryable<Exercise> GetAll()
        {
            var command = new SqliteCommand("SELECT * FROM Exercise");
            return GetRecords(command);
        }

        public Exercise GetById(string id)
        {
            var command = new SqliteCommand(
                "SELECT * FROM Exercise" +
                "WHERE Id=@id");
            command.Parameters.Add(new SqliteParameter("id", id));
            return GetRecord(command);
        }

        public void Insert(Exercise exercise)
        {
            var command = new SqliteCommand(
                "INSERT INTO Exercise (Name, Created)" +
                "VALUES(@name,@created)");
            command.Parameters.Add(new SqliteParameter("name", exercise.Name));
            command.Parameters.Add(new SqliteParameter("created", DateTime.Now.Ticks));
        }

        public void Update(Exercise exercise)
        {
            var command = new SqliteCommand(
                "UPDATE Exercise" +
                "SET Name = @name" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("name", exercise.Name));
        }

        public void Delete(Exercise exercise)
        {
            var command = new SqliteCommand(
                "DELETE Exercise" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("id", exercise.Id));
        }
    }
}
