using GeJu.Common.DTO.Brands;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace GeJu.Api.Main.Test.Brand
{
    internal partial class BrandControllerTest : TestBase
    {
        private readonly string _uri = "api/brands";
        private string _brandId;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [Order(1)]
        public async Task SaveShouldReturnOk()
        {
            var brand = NewBrand;
            var actual = await _sut.PostAsJsonAsync(_uri, brand);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
            Assert.IsTrue(actual.IsSuccessStatusCode);
            var model = await actual.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BrandApi>(model);
            Assert.That(response.Description, Is.EqualTo(brand.Description));
            Assert.That(response.Name, Is.EqualTo(brand.Name));
            _brandId = response.Id.ToString();
        }

        [Test]
        [Order(2)]
        public async Task GetAllShouldReturnOk()
        {
            var actual = await _sut.GetAsync(_uri);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
            var model = await actual.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IEnumerable<BrandApi>>(model);
            CollectionAssert.IsNotEmpty(response);
        }

        [Test]
        [Order(3)]
        public async Task UpdateUserGroupShouldReturnOk()
        {
            var brand = UpdateBrand;
            brand.Id = _brandId;
            var actual = await _sut.PutAsJsonAsync(_uri, brand);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
            Assert.IsTrue(actual.IsSuccessStatusCode);
            var model = await actual.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BrandApi>(model);
            Assert.That(response.Description, Is.EqualTo(brand.Description));
            Assert.That(response.Name, Is.EqualTo(brand.Name));
        }
    }
}
