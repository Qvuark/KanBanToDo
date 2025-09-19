using KanbanToDo.Models;
using KanbanToDo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Stores
{
    public class TasksStore
    {
        private readonly ITaskService _taskService;
        private List<TaskModel> _tasks = new();

        public event Action? TaskChanged;
        public event Action<TaskModel>? TaskCreated;
        public event Action<TaskModel>? TaskUpdated;
        public event Action<int>? TaskDeleted;
        public IReadOnlyList<TaskModel> Tasks => _tasks;
        public TasksStore(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public async Task<IEnumerable<TaskModel>> GetTaskAsync()
        {
            return await _taskService.GetAllTasksAsync();
        }
        public async Task<TaskModel?> GetTaskByIdAsync(int id)
        {
            return await _taskService.GetTaskByIdAsync(id);
        }
        public async Task<TaskModel> CreateTaskAsync(TaskModel task)
        {
            var createdTask = await _taskService.CreateTaskAsync(task);
            
            TaskCreated?.Invoke(createdTask);
            TaskChanged?.Invoke();

            return createdTask;
        }
        public async Task<TaskModel> UpdateTaskAsync(TaskModel task)
        {
            var updatedTask = await _taskService.UpdateTaskAsync(task);

            TaskUpdated?.Invoke(updatedTask);
            TaskChanged?.Invoke();

            return updatedTask;
        }
        public async Task DeleteTaskAsync(int id)
        {
            await _taskService.DeleteTask(id);

            TaskDeleted?.Invoke(id);
            TaskChanged?.Invoke();
        }
    }
}
