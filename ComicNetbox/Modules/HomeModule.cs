using Nancy;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ComicNetbox.Modules
{
    public class HomeModule : NancyModule
    {
        private string rootPath { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        public HomeModule()
        {
            //TODO Get["/"] show dir and click to show comic page

            //Show comic page with path
            ShowPage();

            //Test
            ShowPageTest();
        }

        private void ShowPage()
        {
            // url:~/comic?path=
            Get["/comicpage/{path*}"] = x =>
            {
                //string path = this.Request.Query["path"];
                string path = x.path;
                string comicDir = ConfigurationManager.AppSettings["comicPath"].ToString().TrimStart('/').Replace('/', '\\');
                // C:\Test\comicPath\{path}
                string targetRoot = string.Format(@"{0}{1}\{2}", rootPath, comicDir, path.Replace('/', '\\'));

                DirectoryInfo di = new DirectoryInfo(targetRoot);

                // C:\Test\comicPath\first\
                var pictures = di.GetFiles("*.jpg").ToList();

                // ["first/1.jpg", "first/2.jpg]
                var picUrls = pictures.Select(pic => { return pic.FullName.Substring(rootPath.Length).Replace('\\', '/'); }).ToList();

                return View["/ComicPage", picUrls];
            };
        }

        private void ShowPageTest()
        {
            Get["/Test"] = parameters =>
            {
                // C:\Test\comicPath
                string targetRoot = rootPath + ConfigurationManager.AppSettings["comicPath"].ToString().TrimStart('/').Replace('/', '\\');
                DirectoryInfo di = new DirectoryInfo(targetRoot);

                // C:\Test\comicPath\first\
                var firstFolder = di.GetDirectories()[0];
                var pictures = firstFolder.GetFiles("*.jpg").ToList();

                // ["first/1.jpg", "first/2.jpg]
                var picUrls = pictures.Select(pic => { return pic.FullName.Substring(rootPath.Length).Replace('\\', '/'); }).ToList();

                return View["/Home", picUrls];
            };
        }
    }
}