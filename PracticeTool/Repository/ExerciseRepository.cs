using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Repository {
    class ExerciseRepository : AdoRepository<Exercise> {
        public ExerciseRepository(string connectionString) : base(connectionString)
        {
        }

        public override Exercise PopulateRecord(DbDataReader reader)
        {
            var id = reader.GetInt32("Id");
            var name = reader.GetString("Name");
            var created = reader.GetInt64("Created");

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

        public void Insert(Exercise exercise, params Component[] components)
        {
            var getNextAuto = new SqliteCommand("SELECT * FROM Exercise " +
                "ORDER BY Id DESC " +
                "LIMIT 1");
            var last = GetRecord(getNextAuto);
            var id = last.Id+1;
            var commands = new List<SqliteCommand>();
            
            commands.Add(new SqliteCommand(
                "INSERT INTO Exercise (Id, Name, Created)" +
                "VALUES(@id, @name, @created)"));
            commands[0].Parameters.Add(new SqliteParameter("name", exercise.Name));
            commands[0].Parameters.Add(new SqliteParameter("created", DateTime.Now.Ticks));
            commands[0].Parameters.Add(new SqliteParameter("id", id));

            foreach(var component in components) {
                var actualCommand = new SqliteCommand(
                    "INSERT INTO Component (Name, ExerciseId, Placement, ComponentTypeId) " +
                    "VALUES (@name, @exerciseId, @placement, @componentTypeId");
                actualCommand.Parameters.Add(new SqliteParameter("name", component.Name));
                actualCommand.Parameters.Add(new SqliteParameter("exerciseId", id));
                actualCommand.Parameters.Add(new SqliteParameter("placement", component.Placement));
                actualCommand.Parameters.Add(new SqliteParameter("componentTypeId", component.ComponentTypeId));

                commands.Add(actualCommand);
                
                
            }

            Transaction(commands.ToArray());
        }

        public void Update(Exercise exercise)
        {
            var command = new SqliteCommand(
                "UPDATE Exercise " +
                "SET Name = @name, Created = @created " +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("name", exercise.Name));
            command.Parameters.Add(new SqliteParameter("created", exercise.Created));
            command.Parameters.Add(new SqliteParameter("id", exercise.Id));

            Execute(command);
        }

        public void Delete(Exercise exercise)
        {
            var command = new SqliteCommand(
                "DELETE Exercise" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("id", exercise.Id));

            Execute(command);
        }
    }
}
