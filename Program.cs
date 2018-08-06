using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using OSGeo.GDAL;
using System;

namespace gdal
{
    class Program
    {
        public static void Main(string[] args)
        {
            Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            //Gdal.AllRegister();
            //Console.WriteLine("Hello World!");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>      
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        
    }
}
