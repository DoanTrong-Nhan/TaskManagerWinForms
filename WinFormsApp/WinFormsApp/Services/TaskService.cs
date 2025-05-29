using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Models.Task> GetAll() => _repository.GetAll();

        public Models.Task? GetById(int id) => _repository.GetById(id);

        public void Create(Models.Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _repository.Add(task);
            _repository.Save();
        }

        public void Update(Models.Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _repository.Update(task);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public async Task<List<Models.TaskStatus>> GetAllStatusesAsync() =>
            await _repository.GetAllStatusesAsync();

        public async Task<List<TaskPriority>> GetAllPrioritiesAsync() =>
            await _repository.GetAllPrioritiesAsync();

        public async Task<List<User>> GetUsersByRoleAsync(int roleId) =>
            await _repository.GetUsersByRoleAsync(roleId);

        public List<TaskDto> GetAllDtos() => _repository.GetAllWithDetails();

        public List<TaskDto> GetFilteredTasks(string? title, int? statusId, int? priorityId) =>
            _repository.GetFilteredTasks(title, statusId, priorityId);
        public TaskDto? GetDtoById(int taskId) =>
            _repository.GetDtoById(taskId);

        public void UpdateStatus(int taskId, int statusId) =>
            _repository.UpdateStatus(taskId, statusId);
    }
}
