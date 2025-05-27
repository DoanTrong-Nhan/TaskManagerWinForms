using Microsoft.EntityFrameworkCore;
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

        public List<Models.Task> GetAllTasks()
        {
            return _context.Tasks
                .Include(t => t.Priority)  // Eager loading for related entities
                .Include(t => t.Status)
                .Include(t => t.User)
                .ToList();  // Fetches the tasks with their related data
        }

        public Models.Task? GetTaskById(int id)
        {
            return _context.Tasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.User)
                .FirstOrDefault(t => t.TaskId == id);  // Fetches task by ID
        }

        public void Add(Models.Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _context.Tasks.Add(task);  // Adds task to the DbSet
        }

        public void Update(Models.Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _context.Tasks.Update(task);  // Updates the task in the DbSet
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);  // Finds the task by ID
            if (task != null)
                _context.Tasks.Remove(task);  // Removes the task from the DbSet
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();  // Commits changes to the database
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while saving changes to the database.", ex);
            }
        }
        // Phương thức bất đồng bộ để lấy tất cả trạng thái công việc
        public async Task<List<Models.TaskStatus>> GetAllStatuses()
        {
            return await _context.TaskStatuses.ToListAsync();
        }

        // Phương thức bất đồng bộ để lấy tất cả mức độ ưu tiên
        public async Task<List<TaskPriority>> GetAllPriorities()
        {
            return await _context.TaskPriorities.ToListAsync();
        }

        // Phương thức bất đồng bộ để lấy người dùng theo RoleId
        public async Task<List<User>> GetUsersByRole(int roleId)
        {
            return await _context.Users.Where(u => u.RoleId == roleId).ToListAsync();
        }
    }
}