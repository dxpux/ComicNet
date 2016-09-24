using Nancy;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ComicNetbox.Modules
{
    public class HomeModule : NancyModule
    {
        private string rootPath;

        public HomeModule()
        {
            // C:\Test\
            rootPath = AppDomain.CurrentDomain.BaseDirectory;

            // C:\Test\comicPath
            string targetRoot = rootPath + ConfigurationManager.AppSettings["comicPath"].ToString().TrimStart('/').Replace('/', '\\');
            DirectoryInfo di = new DirectoryInfo(targetRoot);

            // C:\Test\comicPath\first\
            var firstFolder = di.GetDirectories()[0];
            var pictures = firstFolder.GetFiles("*.jpg").ToList();

            // ["first/1.jpg", "first/2.jpg]
            var picUrls = pictures.Select(pic => { return pic.FullName.Substring(rootPath.Length).Replace('\\', '/'); }).ToList();
            Get["/"] = parameters =>
            {
                return View["/Home", picUrls];
            };
        }
    }
}