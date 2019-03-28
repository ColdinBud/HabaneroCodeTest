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

        public ActionResult _GetGameList()
        {
            string lang = !string.IsNullOrEmpty(Request.QueryString["locale"]) ? Request.QueryString["locale"] : "en";
            GamesData games = ProcessController.GetGames(new BaseApiData { });
            ViewBag.GameList = games.games;


            Dictionary<int, List<GamesData.Game>> sortedGameList = new Dictionary<int, List<GamesData.Game>>();

            foreach (var game in games.games)
            {
                if (lang != "en")
                {
                    game.translatedName = game.translatedNames.First(x => x.locale == lang).translation;
                }
                if (lang != "zh-CN")
                {
                    game.simplifiedChineseName = game.translatedNames.First(x => x.locale == "zh-CN").translation;
                }

                if (sortedGameList.ContainsKey(game.gameTypeId))
                {
                    sortedGameList[game.gameTypeId].Add(game);
                }
                else
                {
                    sortedGameList.Add(game.gameTypeId, new List<GamesData.Game> { game });
                }
            }



            SelectList langList = new SelectList(sortedGameList[11][0].translatedNames, "locale", "locale", lang);


            ViewBag.LangList = langList;
            ViewBag.Lang = lang;
            ViewBag.SortedGameList = sortedGameList;


            ViewBag.Message = "Your contact page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            /*
            string lang = !string.IsNullOrEmpty(Request.QueryString["locale"]) ? Request.QueryString["locale"] : "en";
            GamesData games = ProcessController.GetGames(new BaseApiData { });
            ViewBag.GameList = games.games;


            Dictionary<int, List<GamesData.Game>> sortedGameList = new Dictionary<int, List<GamesData.Game>>();

            foreach (var game in games.games)
            {
                if (lang != "en")
                {
                    game.translatedName = game.translatedNames.First(x => x.locale == lang).translation;
                }
                if (lang != "zh-CN")
                {
                    game.simplifiedChineseName = game.translatedNames.First(x => x.locale == "zh-CN").translation;
                }

                if (sortedGameList.ContainsKey(game.gameTypeId))
                {
                    sortedGameList[game.gameTypeId].Add(game);
                }
                else
                {
                    sortedGameList.Add(game.gameTypeId, new List<GamesData.Game> { game });
                }
            }

            

            SelectList langList = new SelectList(sortedGameList[11][0].translatedNames, "locale", "locale", lang);

            
            ViewBag.LangList = langList;
            ViewBag.Lang = lang;
            ViewBag.SortedGameList = sortedGameList;
            */

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}