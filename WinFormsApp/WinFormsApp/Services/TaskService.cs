using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _repository.GetAll();
        }

        public Models.Task? GetTaskById(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateTask(Models.Task task)
        {
            _repository.Add(task);
            _repository.Save();
        }

        public void UpdateTask(Models.Task task)
        {
            _repository.Update(task);
            _repository.Save();
        }

        public void DeleteTask(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }

}
