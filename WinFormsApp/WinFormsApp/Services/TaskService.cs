using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Dtos;
using WinFormsApp.Models;
using WinFormsApp.Repositories;

namespace WinFormsApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public List<Models.Task> GetAllTasks()
        {
            try
            {
                return _repository.GetAllTasks();  // Fetches all tasks
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error retrieving tasks.", ex);
            }
        }

        public List<TaskDto> GetAllTaskDtos()
        {
            var tasks = _repository.GetAllTasksWithDetails();

            return tasks.Select(t => new TaskDto
            {
                TaskId = t.TaskId,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                DueDate = t.DueDate,
                PriorityName = t.Priority?.PriorityName,
                StatusName = t.Status?.StatusName,
                UserFullName = t.User?.FullName
            }).ToList();
        }


        public Models.Task? GetTaskById(int id)
        {
            try
            {
                return _repository.GetTaskById(id);  // Fetches a task by ID
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving task with ID {id}.", ex);
            }
        }

        public void CreateTask(Models.Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");

            try
            {
                _repository.Add(task);  // Adds task to the repository
                _repository.Save();  // Commits to the database
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating task.", ex);
            }
        }

        public void UpdateTask(Models.Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");

            try
            {
                _repository.Update(task);  // Updates task in the repository
                _repository.Save();  // Commits to the database
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating task.", ex);
            }
        }

        public void DeleteTask(int id)
        {
            try
            {
                _repository.Delete(id);  // Deletes task from the repository
                _repository.Save();  // Commits to the database
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting task.", ex);
            }
        }

        // Lấy tất cả trạng thái công việc (asynchronous)
        public async Task<List<Models.TaskStatus>> GetAllStatuses()
        {
            return await _repository.GetAllStatuses();
        }

        // Lấy tất cả mức độ ưu tiên (asynchronous)
        public async Task<List<TaskPriority>> GetAllPriorities()
        {
            return await _repository.GetAllPriorities();
        }

        // Lấy người dùng theo RoleId (asynchronous)
        public async Task<List<User>> GetUsersByRole(int roleId)
        {
            return await _repository.GetUsersByRole(roleId);
        }

        public List<TaskDto> SearchTasks(string? title, int? statusId, int? priorityId)
        {
            return _repository.GetFilteredTasks(title, statusId, priorityId);
        }
    }
}