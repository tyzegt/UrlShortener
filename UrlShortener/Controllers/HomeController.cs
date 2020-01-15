using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Web.DbModels;
using UrlShortener.Models;
using UrlShortener.Web.Models;
using UrlShortener.Web.DbService;

namespace UrlShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        IRepository Repository;
        public HomeController(IRepository repo)
        {
            Repository = repo;
        }

        [HttpGet]
        public IActionResult Index(string word)
        {
            if(word!="Default")
            {
                var Link = Repository.GetLongUrl(word);
                if (Link != null)
                {
                    Repository.IncreaseClickCounter(Link.Key);
                    return Redirect(Link.Url);
                }
                else
                {
                    ModelState.AddModelError("NoSuchLink", "Указанной вами ссылки не существует.");
                }
            }
            var links = Repository.GetAllLinks();
            return View(links);
        }

        [HttpGet]
        public IActionResult NewLink()
        {
            return View(new NewLinkViewModel());
        }

        [HttpPost]
        public IActionResult NewLink(NewLinkViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Repository.CreateNewLink(vm.LinkToAdd);
                return RedirectToAction("Index","Home"); 
            } 
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult DeleteLink(string key)
        {
            Repository.DeleteLink(key);
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
