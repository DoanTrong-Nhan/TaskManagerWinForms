using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Services
{
    public interface ITaskService
    {
        List<Models.Task> GetAllTasks();
        Models.Task? GetTaskById(int id);
        void CreateTask(Models.Task task);
        void UpdateTask(Models.Task task);
        void DeleteTask(int id);

    }

}
