using agl.Core.Factories;
using agl.Core.Interfaces;
using agl.Core.Models;
using agl.MvcSite.Models;
using agl.MvcSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace agl.MvcSite.Controllers
{
    public class HomeController : Controller
    {
        private JsonStringSearchService _jsonStringSearchService = new JsonStringSearchService();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            CatListResponse res = await _jsonStringSearchService.GetCatListByOwnerGendersAsync();
            return View(res);
        }
    }
}