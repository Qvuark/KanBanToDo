using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Models
{
    class Column
    {
        public string Name { get;}
        private readonly List<Task> Tasks;
        public Column(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }
    }
}
