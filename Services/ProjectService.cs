using KanbanToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.Services
{
    public class ProjectService : IProjectService
    {
        private readonly List<Project> projects = new List<Project>();
        private int nextId;
        public ProjectService()
        {
            projects.Add(new Project
            {
                Id = 1,
                Name = "First Project",
                Author = "Admin",
                CreateDate = DateTime.Now,
                Description = "This is the first project",
                IsActive = true
            });
            projects.Add(new Project
            {
                Id = 2,
                Name = "Second Project",
                Author = "Admin",
                CreateDate = DateTime.Now,
                Description = "This is the second project",
                IsActive = true
            });
        }
        public Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return Task.FromResult(projects.Where(p => p.IsActive).AsEnumerable());
        }
        public Task<Project?> GetProjectByIdAsync(int projectId)
        {
            var project = projects.FirstOrDefault(p => p.Id == projectId && p.IsActive);
            return Task.FromResult(project);
        }
        public Task<Project> CreateProjectAsync(Project project)
        {
            project.Id = ++nextId;
            project.CreateDate = DateTime.Now;
            project.IsActive = true;
            projects.Add(project);
            return Task.FromResult(project);
        }
        public Task<Project> UpdateProjectAsync(Project project)
        {
            var existingProject = projects.FirstOrDefault(p => p.Id == project.Id && p.IsActive);
            if (existingProject != null)
            {
                existingProject.Name = project.Name;
                existingProject.Description = project.Description;
                existingProject.Author = project.Author;
            }
            return Task.FromResult(existingProject);
        }
        public Task DeleteProject(int id)
        {
            var existingProject = projects.FirstOrDefault(p => p.Id == id && p.IsActive);
            if (existingProject != null)
            {
                existingProject.IsActive = false;
            }
            return Task.CompletedTask;
        }
    }
}
