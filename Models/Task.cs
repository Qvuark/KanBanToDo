using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Models
{
    class Task
    {
        public int Id { get;}
        public string Title { get;}
        public string Description { get;}
        public DateTime DueDate { get;}
        public TaskStatus Status { get;}
        public Priority Priority { get;}
        public Task(int id, string title, string description, DateTime dueDate, TaskStatus status, Priority priority)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
        }
    }
}
