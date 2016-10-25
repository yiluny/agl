using agl.Core.Interfaces;
using agl.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace agl.Core.Factories
{
    public class JsonSearchFactory : ISearch<Person>
    {
        private string _jsonStrDataSourceUrl;

        public JsonSearchFactory(string jsonStrDataSourceUrl = "http://agl-developer-test.azurewebsites.net/people.json")
        {
            _jsonStrDataSourceUrl = jsonStrDataSourceUrl;
        }

        public List<string> GetSearchStringResultsByGender(List<Person> data, string gender)
        {
            List<string> searchedData = new List<string>();
            if (data != null && !string.IsNullOrWhiteSpace(gender))
            {
                searchedData = data.Where(p => p.Gender.ToLower().Equals(gender) && p.Pets != null)
                                            .SelectMany(p => p.Pets)
                                            .Where(pet => pet.Type.Equals(AnimalType.cat))
                                            .Select(pet => pet.Name)
                                            .OrderBy(k => k)
                                            .ToList();
            }

            return searchedData;
        }

        public async Task<string> GetStringFormatFromDataSourceAsync()
        {
            HttpClient client = new HttpClient();
            string jsonStr = string.Empty;

            jsonStr = await client.GetStringAsync(_jsonStrDataSourceUrl);
            return jsonStr;
        }

        public List<Person> Transform(string dataSource)
        {
            List<Person> dataList = new List<Person>();
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                dataList = JsonConvert.DeserializeObject<List<Person>>(dataSource);
            }

            return dataList;
        }
    }
}