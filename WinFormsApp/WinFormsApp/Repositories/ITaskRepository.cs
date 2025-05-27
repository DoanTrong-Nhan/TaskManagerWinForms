using System.Collections.Generic;
using WinFormsApp.Models;

namespace WinFormsApp.Repositories
{
    public interface ITaskRepository
    {
        List<Models.Task> GetAll();
        Models.Task? GetById(int id);
        void Add(Models.Task task);
        void Update(Models.Task task);
        void Delete(int id);
        void Save();
    }
}
