using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KanbanToDo.ViewModels
{
    public class ViewModeSelectorViewModel : MainWindowViewModel
    {
        public ICommand ChangeTypeOfViewCommand { get; }
    }
}
