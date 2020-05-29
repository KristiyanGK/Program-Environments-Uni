using System;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentInfoSystem.Data;
using StudentInfoSystem.Services;
using StudentInfoSystem.Views;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConfigPath = "appsettings.json";

        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigPath, optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var loginView = ServiceProvider.GetRequiredService<LoginView>();
            loginView.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<LoginView>();
            services.AddTransient<StudentService>();
            services.AddTransient<StudentValidation>();

            services.AddDbContext<StudentInfoContext>(options 
                => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
