using MongoDB.Bson;
using MongoDB.Driver;
using ToDoListAPI.Data;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Service
{
    public class ToDoService
    {
        private readonly IMongoCollection<TaskItem> _tasksCollection;

        public ToDoService(DataContext dbContext)
        {
            _tasksCollection = dbContext.Tasks;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItems()
        {
            return await _tasksCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TaskItem> GetTaskItemById(string id)
        {
            var filter = Builders<TaskItem>.Filter.Eq("_id", ObjectId.Parse(id));

            return await _tasksCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<TaskItem> CreateTaskItem(TaskItem task)
        {
            task.CreateDate = DateTime.Now;
            await _tasksCollection.InsertOneAsync(task);
            return task;
        }

        public async Task<bool> UpdateTaskItem(TaskItem task)
        {
            var filter = Builders<TaskItem>.Filter.Eq("_id", ObjectId.Parse(task.Id));

            var update = Builders<TaskItem>.Update
                .Set(t => t.Title, task.Title)
                .Set(t => t.Description, task.Description)
                .Set(t => t.CreateDate, task.CreateDate)
                .Set(t => t.Status, task.Status);

            var result = await _tasksCollection.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteTaskItem(string id)
        {
            var filter = Builders<TaskItem>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await _tasksCollection.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}