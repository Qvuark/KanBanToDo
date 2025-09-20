using KanbanToDo.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KanbanToDo.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProjectsTree.xaml
    /// </summary>
    public partial class ProjectsTree : UserControl
    {
        public ProjectsTree()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                DataContext = App.ServiceProvider.GetRequiredService<ProjectsTreeViewModel>();
            }
        }
    }
}
