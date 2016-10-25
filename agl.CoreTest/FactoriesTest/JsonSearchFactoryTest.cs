using agl.Core.Factories;
using agl.Core.Interfaces;
using agl.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agl.CoreTest.FactoriesTest
{
    [TestClass]
    public class JsonSearchFactoryTest
    {
        private ISearch<Person> _jsonSearchFactory = new JsonSearchFactory();

        [TestMethod]
        public async Task GetSearchStringResultsByGenderAsyncTest()
        {
            Task<string> jsonStr = _jsonSearchFactory.GetStringFormatFromDataSourceAsync();
            string jsonStrResult = await jsonStr;

            List<Person> data = _jsonSearchFactory.Transform(jsonStrResult);
            List<string> cats = _jsonSearchFactory.GetSearchStringResultsByGender(data, "male");

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Any());
        }

        [TestMethod]
        public async Task GetStringFormatFromDataSourceAsyncTest()
        {
            Task<string> jsonStr = _jsonSearchFactory.GetStringFormatFromDataSourceAsync();

            string jsonStrResult = await jsonStr;

            Assert.IsNotNull(jsonStrResult);
        }

        [TestMethod]
        public async Task DataTransformAsyncTest()
        {
            Task<string> jsonStr = _jsonSearchFactory.GetStringFormatFromDataSourceAsync();
            string jsonStrResult = await jsonStr;

            List<Person> data = _jsonSearchFactory.Transform(jsonStrResult);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Any());
        }
    }
}