using agl.Core.Factories;
using agl.Core.Interfaces;
using agl.Core.Models;
using agl.MvcSite.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace agl.MvcSite.Services
{
    public class JsonStringSearchService
    {
        private ISearch<Person> _jsonSearchFactory = new JsonSearchFactory();

        public async Task<CatListResponse> GetCatListByOwnerGendersAsync()
        {
            try
            {
                string jsonStr = await _jsonSearchFactory.GetStringFormatFromDataSourceAsync();
                List<Person> dataList = _jsonSearchFactory.Transform(jsonStr);
                CatListResponse res = new CatListResponse()
                {
                    MaleOwnerCats = _jsonSearchFactory.GetSearchStringResultsByGender(dataList, "male"),
                    FemaleOwnerCats = _jsonSearchFactory.GetSearchStringResultsByGender(dataList, "female"),
                };
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}