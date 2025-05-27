using System.Collections.Generic;
using System.Threading.Tasks;
using WinFormsApp.Dtos;
using WinFormsApp.Models;

namespace WinFormsApp.Repositories
{
    public interface ITaskRepository
    {
        // CRUD
        List<Models.Task> GetAll();
        Models.Task? GetById(int id);
        void Add(Models.Task task);
        void Update(Models.Task task);
        void Delete(int id);
        void Save();

        // Lookup
        Task<List<Models.TaskStatus>> GetAllStatusesAsync();
        Task<List<TaskPriority>> GetAllPrioritiesAsync();
        Task<List<User>> GetUsersByRoleAsync(int roleId);

        // DTO
        List<TaskDto> GetAllWithDetails();
        List<TaskDto> GetFilteredTasks(string? title, int? statusId, int? priorityId);
        List<TaskDto> GetByUserId(int userId);
        TaskDto? GetDtoById(int taskId);

        // Custom Updates
        void UpdateStatus(int taskId, int statusId);
    }
}
