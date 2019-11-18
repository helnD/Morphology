using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(MorphologyService morphology)
        {

            if (Request.Query.Count != 0)
            {
                var image = new Image(Request.Query).Model;
                var result = morphology.Calculate(image, Request.Query["operation"])
                    .ColorMatrix();
                return Json(result);
            }

            return View();
        }
    }
}