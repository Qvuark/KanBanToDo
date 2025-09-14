using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Models
{
    class Column
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.NotStated;
        public required ObservableCollection<TaskModel> Tasks { get; set; }
        public int MaxTaskLimit { get; set; } = 6;
    }
}
