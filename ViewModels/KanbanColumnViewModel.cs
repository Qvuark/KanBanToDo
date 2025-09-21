using KanbanToDo.Models;
using KanbanToDo.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.ViewModels
{
    public class KanbanColumnViewModel : BaseViewModel
    {
        private readonly TasksStore _tasksStore;
        private readonly Models.TaskStatus _status;
        private ObservableCollection<TaskModel> _tasks;

        public string Title { get; }
        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }
        public KanbanColumnViewModel(TasksStore tasksStore, Models.TaskStatus status)
        {
            _status = status;
            _tasksStore = tasksStore;
            Title = status.ToString();
            _tasksStore.TaskChanged += LoadTasksAsync;

            LoadTasksAsync();
        }
        private async void LoadTasksAsync()
        {
            var allTasks = await _tasksStore.GetAllTasksAsync();
            var filteredTasks = allTasks.Where(t => t.Status == _status);
            Tasks = new ObservableCollection<TaskModel>(filteredTasks);
            OnPropertyChanged(nameof(Tasks));
        }
    }
}
