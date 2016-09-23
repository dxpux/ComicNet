using Microsoft.Owin.Hosting;
using Nancy;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicNetbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<MySartup>("http://+:8080"))
            {
                Console.WriteLine("OWIN hosting, press enter to exit");
                Console.Read();
            }
        }
    }

    public class MySartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
