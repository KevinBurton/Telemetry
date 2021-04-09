using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simulator.Common;
using System;
using System.IO;
using System.Windows;

namespace Simulator
{
    //https://stackoverflow.com/questions/59909207/cannot-add-appsettings-json-inside-wpf-project-net-core-3-0
    //https://executecommands.com/dependency-injection-in-wpf-net-core-csharp/
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            System.Diagnostics.Debug.WriteLine($"Address: {Configuration["Satelite:Address"]} Port: {Configuration["Satelite:Port"]}");

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.Configure<SateliteConfiguration>
                (Configuration.GetSection(nameof(SateliteConfiguration)));
            services.AddTransient(typeof(MainWindowViewModel));
        }
    }
}
