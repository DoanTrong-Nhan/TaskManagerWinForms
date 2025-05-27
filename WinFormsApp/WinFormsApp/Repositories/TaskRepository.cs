using System.Collections.Generic;
using System.Linq;
using WinFormsApp.Models;

namespace WinFormsApp.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDbContext _context;

        public TaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public List<Models.Task> GetAll() => _context.Tasks.ToList();

        public Models.Task? GetById(int id) => _context.Tasks.Find(id);

        public void Add(Models.Task task) => _context.Tasks.Add(task);

        public void Update(Models.Task task) => _context.Tasks.Update(task);

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
                _context.Tasks.Remove(task);
        }

        public void Save() => _context.SaveChanges();
    }
}
