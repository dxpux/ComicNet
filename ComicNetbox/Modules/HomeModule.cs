﻿using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicNetbox.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                return View["/Home"];
            };
        }
    }
}