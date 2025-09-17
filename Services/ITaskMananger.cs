using KanbanToDo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Services
{
    public interface ITaskMananger
    {
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<IEnumerable<TaskModel>> GetAllTasksByIdAsync(int id);
        Task<TaskModel> GetTaskByIdAsync(int taskId);
        Task<TaskModel> CreateTaskAsync(TaskModel task);
        Task<TaskModel> UpdateTaskAsync(TaskModel task);
        Task DeleteTask(TaskModel task);
    }
}
