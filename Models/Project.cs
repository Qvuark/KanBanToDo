using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public required List<Task> Tasks { get; set; }
    }
}
