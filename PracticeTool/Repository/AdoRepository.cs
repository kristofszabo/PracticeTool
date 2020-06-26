using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace TPHDatabase.Repository {
    abstract class AdoRepository<T> where T: class {

        SqliteConnection _connection;

        public AdoRepository(string connectionString)
        {
            var connStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = connectionString
            };
            _connection = new SqliteConnection(connStringBuilder.ConnectionString);
        }


        public abstract T PopulateRecord(DbDataReader reader);

        public  IQueryable<T> GetRecords(DbCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;

            using (_connection)
            {
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(PopulateRecord(reader));
                }
            }
            return list.AsQueryable();

        }

        public T GetRecord(DbCommand command)
        {
            T record = null;
            command.Connection = _connection;

            using (_connection)
            {
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    record = PopulateRecord(reader);
                    break;
                }
            }
            return record;

        }
        protected void Execute(DbCommand command)
        {
            command.Connection = _connection;
            using (_connection) {
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        protected void Transaction(params DbCommand[] commands)
        {
            foreach(var command in commands)
            {
                command.Connection = _connection;
            }
            using(var transaction = _connection.BeginTransaction())
            {
                foreach(var command in commands)
                {
                    command.ExecuteNonQuery();
                }


                transaction.Commit();
            }
        }
    }
}
