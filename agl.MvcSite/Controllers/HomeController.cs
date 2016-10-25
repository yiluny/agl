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
        private ISearch<Person> _jsonSearchFactory = new JsonSearchFactory();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            string jsonStr = await _jsonSearchFactory.GetStringFormatFromDataSourceAsync();
            List<Person> dataList = _jsonSearchFactory.Transform(jsonStr);
            CatListResponse res = new CatListResponse()
            {
                MaleOwnerCats = _jsonSearchFactory.GetSearchStringResultsByGender(dataList, "male"),
                FemaleOwnerCats = _jsonSearchFactory.GetSearchStringResultsByGender(dataList, "female"),
            };
            return View(res);
        }
    }
}