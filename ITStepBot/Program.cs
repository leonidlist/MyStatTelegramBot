using System;
using Telegram.Bot;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using MyStatAPI;
using System.Threading;
using System.Threading.Tasks;

namespace ITStepBot
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Login
            Graphics.ShowHello();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (password?.Length != 0)
                        password = password?.Remove(password.Length - 1);
                }
                else
                    password += key.KeyChar;
            }
            Console.Write(Environment.NewLine);
            #endregion

            Api myStat = new Api(username, password, Cities.Kyiv);
            myStat.TryLogin();
            
            try
            {
                myStat.CollectDailyPoints();
                //myStat.CollectDailyPoints();
                //int counter = 0;
                //foreach(var hwe in myStat.Homeworks)
                //{
                //    Console.WriteLine(++counter + " " + hwe.Id + " => " + hwe.Theme);
                //}
                //Console.WriteLine("Choose id >> ");
                //int id = int.Parse(Console.ReadLine());
                //Console.WriteLine("Sleeping... 2sec");
                //Thread.Sleep(2000);
                ////myStat.UploadHomeworkFile(37559, @"C:\Users\Leonid\Desktop\lisa.jpg");
                ////myStat.DownloadHomeworkFile(myStat.Homeworks.Find(x => x.Id == id.ToString()));
                Task.WaitAll();
            } catch(Exception e)
            {
                Logger.Log(e.Message, ConsoleColor.Gray);
            }
            Task.WaitAll();
            Console.ReadKey();
        }
    }
}
