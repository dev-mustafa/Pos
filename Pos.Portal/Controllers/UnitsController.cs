﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace POS.Portal.Controllers
{
    public class UnitsController : Controller
    {
        // GET: Units
        public ActionResult Index()
        {
            return View();
        }
    }
}