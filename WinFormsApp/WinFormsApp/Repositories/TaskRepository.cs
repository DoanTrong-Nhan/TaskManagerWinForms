using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WinFormsApp.DBContext;
using WinFormsApp.Dtos;
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

        // CRUD
        public List<Models.Task> GetAll()
        {
            return _context.Tasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.User)
                .ToList();
        }

        public Models.Task? GetById(int id)
        {
            return _context.Tasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.User)
                .FirstOrDefault(t => t.TaskId == id);
        }

        public void Add(Models.Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _context.Tasks.Add(task);
        }

        public void Update(Models.Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _context.Tasks.Update(task);
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null) _context.Tasks.Remove(task);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error saving changes to database.", ex);
            }
        }

        // Lookup
        public async Task<List<Models.TaskStatus>> GetAllStatusesAsync()
        {
            return await _context.TaskStatuses.ToListAsync();
        }

        public async Task<List<TaskPriority>> GetAllPrioritiesAsync()
        {
            return await _context.TaskPriorities.ToListAsync();
        }

        public async Task<List<User>> GetUsersByRoleAsync(int roleId)
        {
            return await _context.Users.Where(u => u.RoleId == roleId).ToListAsync();
        }

        // DTO Queries
        public List<TaskDto> GetAllWithDetails()
        {
            return _context.Tasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.User)
                .Select(t => new TaskDto
                {
                    TaskId = t.TaskId,
                    Title = t.Title,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    DueDate = t.DueDate,
                    PriorityName = t.Priority!.PriorityName,
                    StatusName = t.Status!.StatusName,
                    UserFullName = t.User!.FullName
                }).ToList();
        }

        public List<TaskDto> GetFilteredTasks(string? title, int? statusId, int? priorityId)
        {
            var taskDtos = new List<TaskDto>();

            var connection = _context.Database.GetDbConnection();

            try
            {
                _context.Database.OpenConnection(); 
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_FilterTasks";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Title", title ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@StatusId", statusId ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@PriorityId", priorityId ?? (object)DBNull.Value));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new TaskDto
                            {
                                TaskId = reader.GetInt32(reader.GetOrdinal("TaskId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                StartDate = reader.IsDBNull(reader.GetOrdinal("StartDate")) ? null : reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                DueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null : reader.GetDateTime(reader.GetOrdinal("DueDate")),
                                StatusName = reader.IsDBNull(reader.GetOrdinal("StatusName")) ? null : reader.GetString(reader.GetOrdinal("StatusName")),
                                PriorityName = reader.IsDBNull(reader.GetOrdinal("PriorityName")) ? null : reader.GetString(reader.GetOrdinal("PriorityName")),
                                UserFullName = reader.IsDBNull(reader.GetOrdinal("UserFullName")) ? null : reader.GetString(reader.GetOrdinal("UserFullName")),
                            };

                            taskDtos.Add(dto);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while executing GetFilteredTasks.", ex);
            }
            finally
            {
                _context.Database.CloseConnection(); // Đóng lại sau khi xong
            }

            return taskDtos;
        }

        public List<TaskDto> GetByUserId(int userId)
        {
            var result = new List<TaskDto>();

            using var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open) conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "sp_GetTasksByUserId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserId", userId));

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new TaskDto
                {
                    TaskId = reader.GetInt32(reader.GetOrdinal("TaskId")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    StartDate = reader.IsDBNull(reader.GetOrdinal("StartDate")) ? null : reader.GetDateTime(reader.GetOrdinal("StartDate")),
                    DueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null : reader.GetDateTime(reader.GetOrdinal("DueDate")),
                    StatusName = reader.IsDBNull(reader.GetOrdinal("StatusName")) ? null : reader.GetString(reader.GetOrdinal("StatusName")),
                    PriorityName = reader.IsDBNull(reader.GetOrdinal("PriorityName")) ? null : reader.GetString(reader.GetOrdinal("PriorityName")),
                    UserFullName = reader.IsDBNull(reader.GetOrdinal("UserFullName")) ? null : reader.GetString(reader.GetOrdinal("UserFullName"))
                });
            }

            return result;
        }

        public TaskDto? GetDtoById(int taskId)
        {
            return _context.Tasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.User)
                .Where(t => t.TaskId == taskId)
                .Select(t => new TaskDto
                {
                    TaskId = t.TaskId,
                    Title = t.Title,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    DueDate = t.DueDate,
                    PriorityName = t.Priority != null ? t.Priority.PriorityName : null,
                    StatusName = t.Status != null ? t.Status.StatusName : null,
                    UserFullName = t.User != null ? t.User.FullName : null
                })
                .FirstOrDefault();
        }

        public void UpdateStatus(int taskId, int statusId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task == null) throw new Exception("Task not found.");
            task.StatusId = statusId;
            _context.SaveChanges();
        }
    }
}
