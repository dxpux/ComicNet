using Nancy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Conventions;

namespace ComicNetbox
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Clear();

            //set comic path
            string comicPath = ConfigurationManager.AppSettings["comicPath"].ToString();
            nancyConventions.StaticContentsConventions.Add
                (StaticContentConventionBuilder.AddDirectory("comic", comicPath));
            nancyConventions.StaticContentsConventions.Add
                (StaticContentConventionBuilder.AddDirectory("content", "/Content"));
            nancyConventions.StaticContentsConventions.Add
                (StaticContentConventionBuilder.AddDirectory("scripts", "/Scripts"));
        }
    }
}
