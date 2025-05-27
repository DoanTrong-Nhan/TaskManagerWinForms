using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Dtos;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    public interface ITaskService
    {
        List<Models.Task> GetAllTasks();
        Models.Task? GetTaskById(int id);
        void CreateTask(Models.Task task);
        void UpdateTask(Models.Task task);
        void DeleteTask(int id);

        Task<List<Models.TaskStatus>> GetAllStatuses();
        Task<List<TaskPriority>> GetAllPriorities();
        Task<List<User>> GetUsersByRole(int roleId);

        List<TaskDto> GetAllTaskDtos();

        public List<TaskDto> SearchTasks(string? title, int? statusId, int? priorityId);

        List<TaskDto> GetTasksByUserId(int userId);



    }

}
