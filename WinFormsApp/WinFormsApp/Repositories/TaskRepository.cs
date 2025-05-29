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

            try
            {
                _context.Tasks.Add(task);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi thêm Task vào cơ sở dữ liệu.", ex);
            }
        }

        public void Update(Models.Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            try
            {
                _context.Tasks.Update(task);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi cập nhật Task trong cơ sở dữ liệu.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var task = _context.Tasks.Find(id);
                if (task != null)
                {
                    _context.Tasks.Remove(task);
                }
                else
                {
                    throw new KeyNotFoundException($"Không tìm thấy Task với ID = {id} để xóa.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Lỗi khi xóa Task có ID = {id} khỏi cơ sở dữ liệu.", ex);
            }
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
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(SqlConstants.ParamTitle, title ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter(SqlConstants.ParamStatusId, statusId ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter(SqlConstants.ParamPriorityId, priorityId ?? (object)DBNull.Value));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new TaskDto
                            {
                                TaskId = reader.GetInt32(reader.GetOrdinal(SqlConstants.ColTaskId)),
                                Title = reader.GetString(reader.GetOrdinal(SqlConstants.ColTitle)),
                                Description = reader.IsDBNull(reader.GetOrdinal(SqlConstants.ColDescription)) ? null : reader.GetString(reader.GetOrdinal(SqlConstants.ColDescription)),
                                StartDate = reader.IsDBNull(reader.GetOrdinal(SqlConstants.ColStartDate)) ? null : reader.GetDateTime(reader.GetOrdinal(SqlConstants.ColStartDate)),
                                DueDate = reader.IsDBNull(reader.GetOrdinal(SqlConstants.ColDueDate)) ? null : reader.GetDateTime(reader.GetOrdinal(SqlConstants.ColDueDate)),
                                StatusName = reader.IsDBNull(reader.GetOrdinal(SqlConstants.ColStatusName)) ? null : reader.GetString(reader.GetOrdinal(SqlConstants.ColStatusName)),
                                PriorityName = reader.IsDBNull(reader.GetOrdinal(SqlConstants.ColPriorityName)) ? null : reader.GetString(reader.GetOrdinal(SqlConstants.ColPriorityName)),
                                UserFullName = reader.IsDBNull(reader.GetOrdinal(SqlConstants.ColUserFullName)) ? null : reader.GetString(reader.GetOrdinal(SqlConstants.ColUserFullName)),
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
                _context.Database.CloseConnection();
            }

            return taskDtos;
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
