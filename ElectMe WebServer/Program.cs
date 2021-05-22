
using System;
using System.Text.Json;
using ElectMe_WebServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace ElectMe_WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string json = JsonSerializer.Serialize(new TestModel {integer = 333, message = "great message"});
            Console.WriteLine(json);
            TestModel model = JsonSerializer.Deserialize<TestModel>(json);
            Console.WriteLine(model.integer +": "+ model.message);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}