using System;
using System.Collections.Generic;
using System.Linq;
using Todo_List.Core;
using Todo_List.Infrastructure;

namespace Todo_List.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public TaskItem GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(task => task.TaskId == id);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public void Add(TaskItem task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskItem task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(TaskItem task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
