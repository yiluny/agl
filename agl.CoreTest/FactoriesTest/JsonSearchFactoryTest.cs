using AGL.Core.Factories;
using AGL.Core.Interfaces;
using AGL.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.CoreTest.FactoriesTest
{
    [TestClass]
    public class JsonSearchFactoryTest
    {
        private ISearch<Person> _jsonSearchFactory = new JsonSearchFactory();

        [TestMethod]
        public async Task GetSearchStringResultsByGenderAsyncTest()
        {
            var jsonStrResult = await _jsonSearchFactory.GetStringFormatFromDataSourceAsync() ;
            var data = _jsonSearchFactory.Transform(jsonStrResult);
            var cats = _jsonSearchFactory.GetSearchStringResultsByGender(data, "male");
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Any());
            Assert.AreEqual(cats.Count, 4);
        }

        [TestMethod]
        public void GetSearchStringResultsByGenderAsyncWhenDataSourceIsMissingTest()
        {
            var cats = _jsonSearchFactory.GetSearchStringResultsByGender(null, "male");
            Assert.AreEqual(cats.Count,0);
        }

        [TestMethod]
        public async Task GetStringFormatFromDataSourceAsyncTest()
        {
            var jsonStrResult = await _jsonSearchFactory.GetStringFormatFromDataSourceAsync();
            Assert.IsNotNull(jsonStrResult);
        }

        [TestMethod]
        public async Task DataTransformAsyncTest()
        {
            var jsonStrResult = await _jsonSearchFactory.GetStringFormatFromDataSourceAsync();
            var data = _jsonSearchFactory.Transform(jsonStrResult);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Any());
        }

        [TestMethod]
        public void DataTransformWhenDataSourceIsNullAsyncTest()
        {
            var data = _jsonSearchFactory.Transform(string.Empty);
            Assert.AreEqual(data.Count,0);
        }
    }
}