using KanbanToDo.Models;
using KanbanToDo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Stores
{
    public class ProjectsStore
    {

        private readonly IProjectService _projectsService;

        public event Action? ProjectsChanged;
        public event Action<Project>? ProjectCreated;
        public event Action<Project>? ProjectUpdated;
        public event Action<int>? ProjectDeleted;
        public ProjectsStore(IProjectService projectsService)
        {
            _projectsService = projectsService;
        }
        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _projectsService.GetAllProjectsAsync();
        }
        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _projectsService.GetProjectByIdAsync(id);
        }
        public async Task<Project> CreateProjectAsync(Project project)
        {
            var createdProject = await _projectsService.CreateProjectAsync(project);
            ProjectCreated?.Invoke(createdProject);
            ProjectsChanged?.Invoke();
            return createdProject;
        }
        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var updatedProject = await _projectsService.UpdateProjectAsync(project);
            ProjectUpdated?.Invoke(updatedProject);
            ProjectsChanged?.Invoke();
            return updatedProject;
        }
        public async Task DeleteProjectAsync(int id)
        {
            await _projectsService.DeleteProject(id);
            ProjectDeleted?.Invoke(id);
            ProjectsChanged?.Invoke();
        }
    }
}
