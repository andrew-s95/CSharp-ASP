using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null)
            {
                HttpContext.Session.SetInt32("count", 1);
            }
            else
            {
                count += 1;
                HttpContext.Session.SetInt32("count", (int)count);
            }

            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string passcode = "";
            Random rand = new Random();
            for (int i = 1; i <= 14; i++)
            {
                int x = rand.Next(0,36);
                passcode += characters[x];
            }
            ViewBag.Passcode = passcode;
            ViewBag.Count = count;
            return View();
        }
        [HttpGet("/clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
