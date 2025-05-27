using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public List<Models.Task> GetAllTasks()
        {
            return _context.Tasks
                .Include(t => t.Priority)  // Eager loading for related entities
                .Include(t => t.Status)
                .Include(t => t.User)
                .ToList();  // Fetches the tasks with their related data
        }
        public List<Models.Task> GetAllTasksWithDetails()
        {
            return _context.Tasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.User)
                .ToList();
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
        public List<TaskDto> GetFilteredTasks(string? title, int? statusId, int? priorityId)
        {
            var taskDtos = new List<TaskDto>();

            var connection = _context.Database.GetDbConnection();

            try
            {
                _context.Database.OpenConnection(); // Mở kết nối an toàn
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
            finally
            {
                _context.Database.CloseConnection(); // Đóng lại sau khi xong
            }

            return taskDtos;
        }


        //
        public List<TaskDto> GetTasksByUserId(int userId)
        {
            var result = new List<TaskDto>();

            using (var conn = _context.Database.GetDbConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "sp_GetTasksByUserId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserId", userId));

                    using (var reader = cmd.ExecuteReader())
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
                                UserFullName = reader.IsDBNull(reader.GetOrdinal("UserFullName")) ? null : reader.GetString(reader.GetOrdinal("UserFullName"))
                            };

                            result.Add(dto);
                        }
                    }
                }
            }

            return result;
        }


    }
}