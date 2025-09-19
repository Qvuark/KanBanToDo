using KanbanToDo.Models;
using KanbanToDo.Services;
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
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private ObservableCollection<Project> _projects;
        private Project _selectedProject;

        private ProjectsTreeViewModel(IProjectService projectService, ITaskService taskService)
        {
            _taskService = taskService;
            _projectService = projectService;

            AddProject
        }
        public ObservableCollection
    }
}
