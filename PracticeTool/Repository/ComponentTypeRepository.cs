using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using PracticeTool.Models;

namespace PracticeTool.Repository {
    class ComponentTypeRepository : AdoRepository<ComponentType> {
        public ComponentTypeRepository(string connectionString) : base(connectionString)
        {
        }

        public override ComponentType PopulateRecord(DbDataReader reader)
        {
            var name = reader.GetString("Name");
            var id = reader.GetInt32("Id");

            return new ComponentType(id, name);

        }

        public IQueryable<ComponentType> GetAll()
        {
            var command = new SqliteCommand(
                "SELECT * FROM ComponentType");
            return GetRecords(command);
        }

        public void Insert(ComponentType componentType)
        {
            var command = new SqliteCommand(
                "INSERT INTO ComponentType(Name)" +
                "VALUES (@name)");
            command.Parameters.Add(new SqliteParameter("name", componentType.Name));
        }

        internal ComponentType GetById(string id)
        {
            var command = new SqliteCommand(
                "SELECT * FROM ComponentType " +
                "WHERE [Id] = @id");
            command.Parameters.Add(new SqliteParameter("id", id));

            return GetRecord(command);

        }
    }
}
