﻿using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicNet.Modules
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