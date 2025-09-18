using KanbanToDo.Services;
using KanbanToDo.ViewModels;
using KanbanToDo.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace KanbanToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }
        protected override async void OnStartup(StartupEventArgs e)
        {
            host = CreateHostBuilder(e.Args).Build();
            ServiceProvider = host.Services;

            await host.StartAsync();
            
            var mainwindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainwindow.Show();
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
                host.Dispose();
            }
            base.OnExit(e);
        }
        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((Context, services) =>
                {
                    ConfigureServices(services);
                });
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITaskService, TaskService>();    
            services.AddSingleton<IProjectService, ProjectService>();

            services.AddTransient<ProjectsTreeViewModel>();
            services.AddTransient<KanbanBoardViewModel>();
            services.AddTransient<MainWindow>();
        }
    }

}
