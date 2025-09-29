using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.Services.Implementation;
using System.ServiceProcess;
using Microsoft.Extensions.DependencyInjection;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Presentation;

namespace DedaMrazovaRadionica
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            //WinForm inicijalizacija:
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            //Data Layer:
            services.AddSingleton<IDataLayer, DataLayer>();

            //servisi:
            services.AddTransient<IDeteService, DeteService>();

            //forme i usercontrols:
            services.AddTransient<Form1>();
            services.AddTransient<Home>();

            //kreiranje serviceprovider-a:
            ServiceProvider = services.BuildServiceProvider();

            //pokretanje glavne forme:
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }
    }
}