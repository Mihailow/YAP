using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Controllers;
using System.Threading;
using System.Windows;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace server
{
    public class Program
    {
        public static MessagesClass Messages = new MessagesClass();
        public static SessionsClass Sessions = new SessionsClass();
        public static SessionsClass Admin = new SessionsClass();
        public static Users Users = new Users();
        public static List<int> DeletedMessages = new List<int>();


        public static void Main(string[] args)
        {
            TimerCallback tm = new TimerCallback(OnlineControl);
            Timer timer = new Timer(tm, 1, 0, 5000);
            CreateHostBuilder(args).Build().Run();
        }

        public static void OnlineControl(object obj)
        {
            for (int i = 0; i < Sessions.sessions.Count; i++)
            {
                if (Sessions.sessions[i].online == 0)
                {
                    Messages.Add("Server", 0, $"Пользователь {Sessions.sessions[i].login} покинул чат");
                    Console.WriteLine($"Пользователь {Sessions.sessions[i].login} покинул чат.");
                    for (int j = 0; j < Admin.sessions.Count; j++)
                    {
                        if (Sessions.sessions[i].login == Admin.sessions[j].login)
                            Admin.sessions.RemoveAt(j);
                    }
                    Sessions.sessions.RemoveAt(i);
                    i--;
                    continue;
                }
                Sessions.sessions[i].online = 0;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
