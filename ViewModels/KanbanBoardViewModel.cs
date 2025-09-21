using KanbanToDo.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDo.ViewModels
{
    public class KanbanBoardViewModel : BaseViewModel
    {
        private ObservableCollection<KanbanColumnViewModel> _columns = new();
        public ObservableCollection<KanbanColumnViewModel> Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }
        public KanbanBoardViewModel(TasksStore tasksStore)
        {
            CreateColumns(tasksStore);
        }
        private void CreateColumns(TasksStore tasksStore)
        {
            if(_columns is not null)
                _columns.Clear();
            _columns.Add(new KanbanColumnViewModel(tasksStore, Models.TaskStatus.ToDo));
            _columns.Add(new KanbanColumnViewModel(tasksStore, Models.TaskStatus.InProgress));
            _columns.Add(new KanbanColumnViewModel(tasksStore, Models.TaskStatus.Done));
        }
    }
}
