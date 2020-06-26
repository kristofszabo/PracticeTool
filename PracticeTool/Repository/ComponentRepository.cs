using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TPHDatabase.Creators;
using TPHDatabase.Models;
using TPHDatabase.Models.Components;

namespace TPHDatabase.Repository {
    class ComponentRepository : AdoRepository<Component> {

        private ComponentTypeRepository _componentTypeRepository;
        private Dictionary<int, IComponentCreator> dict;
        public ComponentRepository(string connectionString) : base(connectionString)
        {
            _componentTypeRepository = new ComponentTypeRepository(connectionString);
            dict = new Dictionary<int, IComponentCreator>();
            var dictHelper = new Dictionary<string, IComponentCreator>();
            dictHelper.Add("ImageComponent", new ImageComponentCreator());
            dictHelper.Add("DescriptionComponent", new DescriptionComponentCreator());
            dictHelper.Add("PausableTimerComponent", new PausableTimerComponentCreator());
            dictHelper.Add("PdfReaderComponent", new PdfReaderComponentCreator());
            dictHelper.Add("VideoComponent", new VideoComponentCreator());
            dictHelper.Add("VoicePlayerComponent", new VoicePlayerComponentCreator());
            dictHelper.Add("MetronomeComponent", new MetronomeComponentCreator());
            dictHelper.Add("TimerComponent", new TimerComponentCreator());

            var componentTypes = _componentTypeRepository.GetAll();
            foreach(var compType in componentTypes)
            {
                dict.Add(compType.Id, dictHelper[compType.Name]);
            }
        }

        public override Component PopulateRecord(DbDataReader reader)
        {
            //TODO: https://stackoverflow.com/questions/1772025/sql-data-reader-handling-null-column-values
            //Nincs lekezelve ha null van az 1ik értékben
            var id = reader.GetInt32("Id");
            var name = reader.GetString("Name");
            var placement = reader.GetInt32("Placement");
            var exerciseId = reader.GetInt32("ExerciseId");
            var url = reader.GetString("URL");
            var descriptioin = reader.GetString("Description");
            var seconds = reader.GetInt32("Seconds");
            var compTypeId = reader.GetInt32("ComponentTypeId");

            return dict[compTypeId].GetInstantiate(new Component(id, name, placement, exerciseId, compTypeId),url,descriptioin,seconds);
            
        }

        public IQueryable<Component> GetAll()
        {
            var command = new SqliteCommand(
                "SELECT * FROM Component");
            return GetRecords(command);
        }

        public IQueryable<Component> GetAllByExerciseId(string id)
        {
            var command = new SqliteCommand(
                "SELECT * FROM Component" +
                "WHERE ExerciseId = @id");
            command.Parameters.Add(new SqliteParameter("id", id));

            return GetRecords(command);
        }

        public void Delete(string id)
        {
            var command = new SqliteCommand(
                "DELETE Component" +
                "WHERE Id=@id");
            command.Parameters.Add(new SqliteParameter("id", id));
            Execute(command);
        }

        public void Update(Component component)
        {
            var command = new SqliteCommand(
                "UPDATE Component" +
                "SET Name= @name" +
                "SET Placement = @placement" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("name", component.Name));
            command.Parameters.Add(new SqliteParameter("placement", component.Placement));
            command.Parameters.Add(new SqliteParameter("id", component.Id));
        }
        public void Update(SecondsComponent component)
        {
            var command = new SqliteCommand(
                "UPDATE Component" +
                "SET Name= @name" +
                "SET Placement = @placement" +
                "SET Seconds = @seconds" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("name", component.Name));
            command.Parameters.Add(new SqliteParameter("placement", component.Placement));
            command.Parameters.Add(new SqliteParameter("id", component.Id));
            command.Parameters.Add(new SqliteParameter("seconds", component.Seconds));

            Execute(command);
        }
        public void Update(DescriptionComponent component)
        {
            var command = new SqliteCommand(
                "UPDATE Component" +
                "SET Name= @name" +
                "SET Placement = @placement" +
                "SET Description = @description" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("name", component.Name));
            command.Parameters.Add(new SqliteParameter("placement", component.Placement));
            command.Parameters.Add(new SqliteParameter("description", component.Description));
            command.Parameters.Add(new SqliteParameter("id", component.Id));

            Execute(command);
        }

        public void Update(UrlComponent component)
        {
            var command = new SqliteCommand(
                "UPDATE Component" +
                "SET Name= @name" +
                "SET Placement = @placement" +
                "SET URL = @url" +
                "WHERE Id = @id");
            command.Parameters.Add(new SqliteParameter("name", component.Name));
            command.Parameters.Add(new SqliteParameter("placement", component.Placement));
            command.Parameters.Add(new SqliteParameter("url", component.Url));
            command.Parameters.Add(new SqliteParameter("id", component.Id));

            Execute(command);
        }



        //legelején lekérem hogy milyen típusú osztályok vannak
    }
}
