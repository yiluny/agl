using AGL.Core.Interfaces;
using AGL.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGL.Core.Factories
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
            var result = new List<string>();
            if (data != null && !string.IsNullOrWhiteSpace(gender))
            {
                result = data.Where(p => p.Gender.ToLower().Equals(gender) && p.Pets != null)
                                            .SelectMany(p => p.Pets)
                                            .Where(pet => pet.Type.Equals(AnimalType.cat))
                                            .Select(pet => pet.Name)
                                            .OrderBy(k => k)
                                            .ToList();
            }

            return result;
        }

        public async Task<string> GetStringFormatFromDataSourceAsync()
        {
            var result = string.Empty;
            result = await (new HttpClient()).GetStringAsync(_jsonStrDataSourceUrl);
            return result;
        }

        public List<Person> Transform(string dataSource)
        {
            var result = !string.IsNullOrWhiteSpace(dataSource) ? 
                            JsonConvert.DeserializeObject<List<Person>>(dataSource) 
                            : new List<Person>();
            return result;
        }
    }
}