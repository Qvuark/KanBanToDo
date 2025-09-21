using KanbanToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskModel> tasks = new List<TaskModel>();
        private int nextId = 3;
        public TaskService() 
        {
            tasks.AddRange(new[]
            {
                new TaskModel
                {
                    Id = 1,
                    Title = "Глеб лох",
                    Description = "Поздеваться над ним",
                    DueDate = DateTime.Now.AddDays(3),
                    Status = Models.TaskStatus.ToDo,
                    Priority = Priority.Medium,
                    ProjectId = 1
                },
                new TaskModel
                {
                    Id = 1,
                    Title = "КУпить энергос",
                    Description = "та надо бы бля",
                    DueDate = DateTime.Now.AddDays(3),
                    Status = Models.TaskStatus.Done,
                    Priority = Priority.Medium,
                    ProjectId = 3
                },
                new TaskModel
                {
                    Id = 2,
                    Title = "чето там",
                    Description = "та похуй бля",
                    DueDate = DateTime.Now.AddDays(5),
                    Status = Models.TaskStatus.InProgress,
                    Priority = Priority.High,
                    ProjectId = 1
                },
                new TaskModel
                {
                    Id = 2,
                    Title = "послушать земфиру",
                    Description = "прости меня моя любовь",
                    DueDate = DateTime.Now.AddDays(5),
                    Status = Models.TaskStatus.InProgress,
                    Priority = Priority.High,
                    ProjectId = 2
                }
            });

        }
        public Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            return Task.FromResult(tasks.AsEnumerable());
        }
        public Task<IEnumerable<TaskModel>> GetAllTasksByIdAsync(int id)
        {
            return Task.FromResult(tasks.Where(t => t.ProjectId == id).AsEnumerable());
        }
        public Task<TaskModel?> GetTaskByIdAsync(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            return Task.FromResult(task);
        }
        public Task<TaskModel> CreateTaskAsync(TaskModel task)
        {
            if (task == null) 
                throw new ArgumentNullException(nameof(task));
            task.Id = ++nextId;
            task.DateCreated = DateTime.Now;
            tasks.Add(task);
            return Task.FromResult(task);
        }
        public Task<TaskModel> UpdateTaskAsync(TaskModel task)
        {
            if (task == null) 
                throw new ArgumentNullException(nameof(task));
            var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Status = task.Status;
                existingTask.Priority = task.Priority;
                existingTask.ProjectId = task.ProjectId;
            }
            return Task.FromResult(existingTask!);
        }
        public Task DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return Task.CompletedTask;
        }
    }
}
