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
        private string jsonStrDataSourceUrl = "http://agl-developer-test.azurewebsites.net/people.json";

        public List<string> GetSearchStringResultsByGender(List<Person> data, string gender)
        {
            if (data == null || string.IsNullOrWhiteSpace(gender))
            {
                return null;
            }

            List<string> searchedData = data.Where(p => p.Gender.ToLower() == gender && p.Pets != null)
                                            .SelectMany(p => p.Pets)
                                            .Where(pet => pet.Type == AnimalType.cat)
                                            .Select(pet => pet.Name)
                                            .OrderBy(k => k)
                                            .ToList();
            return searchedData;
        }

        public async Task<string> GetStringFormatFromDataSourceAsync()
        {
            HttpClient client = new HttpClient();
            string jsonStr = string.Empty;

            jsonStr = await client.GetStringAsync(jsonStrDataSourceUrl);
            return jsonStr;
        }

        public List<Person> Transform(string dataSource)
        {
            if (string.IsNullOrWhiteSpace(dataSource))
            {
                return null;
            }

            List<Person> dataList = JsonConvert.DeserializeObject<List<Person>>(dataSource);
            return dataList;
        }
    }
}