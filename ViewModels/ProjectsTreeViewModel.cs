using KanbanToDo.Models;
using KanbanToDo.Services;
using KanbanToDo.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KanbanToDo.ViewModels
{
    public class ProjectsTreeViewModel : BaseViewModel
    {
        private readonly TasksStore _taskStore;
        private readonly ProjectsStore _projectStore;
        private ObservableCollection<Project> _projects = new();
        private Project? _selectedProject;

        public ProjectsTreeViewModel(ProjectsStore projectStore, TasksStore taskStore)
        {
            _taskStore = taskStore;
            _projectStore = projectStore;

            _projectStore.ProjectsChanged += LoadProjectsAsync;
            _taskStore.TaskChanged += LoadProjectsAsync;
            LoadProjectsAsync();

        }
        public async void LoadProjectsAsync()
        {
            var projects = await _projectStore.GetProjectsAsync();
            _projects.Clear();
            foreach (var project in projects)
            {
                var tasks = await _taskStore.GetAllTasksByIdAsync(project.Id);
                project.Tasks.Clear();
                foreach(var task in tasks)
                {
                    project.Tasks.Add(task);
                }
                _projects.Add(project);
            }
            //OnPropertyChanged(nameof(Projects));
        }
        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set => SetProperty(ref _projects, value);
        }
        public Project? SelectedProject
        {
            get => _selectedProject;
            set => SetProperty(ref _selectedProject, value);
        }

    }
}
