using KanbanToDo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Services
{
    public interface IProjectMananger
    {
        Task<IEnumerable<TaskModel>> GetTaskModelsAsync(int projectId);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task DeleteProject(Project project);
    }
}
