using System.Collections.Generic;

namespace Todo_List.Core
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Define business logic methods here
        public TaskItem GetTaskById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public void AddTask(TaskItem task)
        {
            _taskRepository.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task != null)
            {
                _taskRepository.Delete(task);
            }
        }
    }
}