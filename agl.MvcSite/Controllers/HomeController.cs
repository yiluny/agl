using AGL.Core.Factories;
using AGL.Core.Interfaces;
using AGL.Core.Models;
using AGL.MvcSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AGL.MvcSite.Controllers
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