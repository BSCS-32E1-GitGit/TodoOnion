using System.Collections.Generic;

namespace Todo_List.Core
{
    public interface ITaskRepository
    {
        TaskItem GetById(int id);
        IEnumerable<TaskItem> GetAll();
        void Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(TaskItem task);
    }
}