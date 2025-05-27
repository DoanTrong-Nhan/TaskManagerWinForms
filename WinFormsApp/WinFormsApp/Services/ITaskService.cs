using System.Collections.Generic;
using System.Threading.Tasks;
using WinFormsApp.Dtos;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    public interface ITaskService
    {
        List<Models.Task> GetAll();
        Models.Task? GetById(int id);
        void Create(Models. Task task);
        void Update(Models.Task task);
        void Delete(int id);

        Task<List<Models.TaskStatus>> GetAllStatusesAsync();
        Task<List<TaskPriority>> GetAllPrioritiesAsync();
        Task<List<User>> GetUsersByRoleAsync(int roleId);

        List<TaskDto> GetAllDtos();
        List<TaskDto> GetFilteredTasks(string? title, int? statusId, int? priorityId);
        List<TaskDto> GetTasksByUserId(int userId);
        TaskDto? GetDtoById(int taskId);
        void UpdateStatus(int taskId, int statusId);
    }
}
