using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NinjaGold.Models;
using Microsoft.AspNetCore.Http;

namespace NinjaGold.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? gold = HttpContext.Session.GetInt32("gold");
            string act = HttpContext.Session.GetString("act");
            if (gold == null)
            {
                HttpContext.Session.SetInt32("gold", 0);
            }
            ViewBag.gold = gold;
            ViewBag.act = act;
            return View();
        }
        [HttpPost("farm")]
        public RedirectToActionResult Farm()
        {   
            int? gold = HttpContext.Session.GetInt32("gold");
            Random randy = new Random();
            int actgold = randy.Next(10,21);
            gold += actgold;
            HttpContext.Session.SetInt32("gold", (int) gold);
            HttpContext.Session.SetString("act", ($"we got {actgold} from farm"));
            return RedirectToAction("Index");
        }
        [HttpPost("cave")]
        public RedirectToActionResult Cave()
        {
            int? gold = HttpContext.Session.GetInt32("gold");
            Random randy = new Random();
            int actgold = randy.Next(5,11);
            gold += actgold;
            HttpContext.Session.SetInt32("gold", (int) gold);
            HttpContext.Session.SetString("act", ($"we got {actgold} from cave"));
            return RedirectToAction("Index");
        }
        [HttpPost("home")]
        public RedirectToActionResult Home()
        {
            int? gold = HttpContext.Session.GetInt32("gold");
            Random randy = new Random();
            int actgold = randy.Next(2,6);
            gold += actgold;
            HttpContext.Session.SetInt32("gold", (int) gold);
            HttpContext.Session.SetString("act", ($"we got {actgold} from home"));
            return RedirectToAction("Index");
        }
        [HttpPost("casino")]
        public RedirectToActionResult Casino()
        {
            int? gold = HttpContext.Session.GetInt32("gold");
            Random randy = new Random();
            int actgold = randy.Next(-50,50);
            gold += actgold;
            HttpContext.Session.SetInt32("gold", (int) gold);
            HttpContext.Session.SetString("act", ($"we got {actgold} from casino"));
            return RedirectToAction("Index");
        }
        [HttpGet("clear")]
        public RedirectToActionResult Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

}
