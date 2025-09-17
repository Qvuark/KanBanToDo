using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public TaskStatus Status { get; set; } = TaskStatus.NotStated;
        public int ProjectId { get; set; }
        public Priority Priority { get; set; } = Priority.Low;
        /*public TaskModel(int id, string title, string description, DateTime dueDate, TaskStatus status, Priority priority)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
        }*/
    }
}
