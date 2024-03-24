using MongoDB.Driver;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Data
{
    public class DataContext
    {
        private readonly IMongoDatabase _database;

        public DataContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<TaskItem> Tasks
        {
            get
            {
                return _database.GetCollection<TaskItem>("tasks");
            }
        }
    }
}
