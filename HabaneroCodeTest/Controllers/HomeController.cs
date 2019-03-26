using HabaneroCodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabaneroCodeTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            GamesData games = ProcessController.GetGames(new BaseApiData { });
            ViewBag.GameList = games.games;

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}