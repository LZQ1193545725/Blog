﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog;
using Blog.Models;
using Newtonsoft.Json;

namespace Blog.Controllers
{
    public class AboutMeController : BaseController
    {
        // GET: AboutMe
        public ActionResult Index()
        {
            
            return View();
        }
    }
}