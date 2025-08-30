using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Models
{
    class Project
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public Project() => Tasks = new ObservableCollection<Task>();
    }
}
