using System.Collections.Generic;
using WinFormsApp.Models;

namespace WinFormsApp.Repositories
{
    public interface ITaskRepository
    {
        List<Models.Task> GetAllTasks();
        Models.Task? GetTaskById(int id);
        void Add(Models.Task task);
        void Update(Models.Task task);
        void Delete(int id);
        void Save();

        Task<List<Models.TaskStatus>> GetAllStatuses();
        Task<List<TaskPriority>> GetAllPriorities();
        Task<List<User>> GetUsersByRole(int roleId);

        List<Models.Task> GetAllTasksWithDetails();
    }
}
