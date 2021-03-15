using GeJu.Api.Main.Models.Users;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Test.Admin
{
    internal class UserControllerTest : TestBase
    {
        private readonly string _uri = "api/users";
        private string _userId;

        [Test]
        [Order(1)]
        public async Task SaveShouldReturnOk()
        {
            var user = Mother.NewUser;
            var actual = await _sut.PostAsJsonAsync(_uri, user);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
            var model = await actual.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<UserApi>(model);
            Assert.That(response.Name, Is.EqualTo(Mother.NewUser.Name));
            Assert.That(response.LastName, Is.EqualTo(Mother.NewUser.LastName));
            Assert.That(response.Email, Is.EqualTo(Mother.NewUser.Email));
            Assert.That(response.Country, Is.EqualTo(Mother.NewUser.Country));
            _userId = response.Id.ToString();
        }

        [Test]
        [Order(2)]
        public async Task GetAllShouldReturnOk()
        {
            var actual = await _sut.GetAsync(_uri);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
            var model = await actual.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IEnumerable<UserApi>>(model);
            CollectionAssert.IsNotEmpty(response);
        }

        [Test]
        [Order(3)]
        public async Task UpdateUserGroupShouldReturnOk()
        {
            var brand = Mother.UpdateUser;
            brand.Id = _userId;
            var actual = await _sut.PutAsJsonAsync(_uri, brand);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
            var model = await actual.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<UserApi>(model);
            Assert.That(response.Name, Is.EqualTo(Mother.UpdateUser.Name));
            Assert.That(response.LastName, Is.EqualTo(Mother.UpdateUser.LastName));
            Assert.That(response.Email, Is.EqualTo(Mother.UpdateUser.Email));
            Assert.That(response.Country, Is.EqualTo(Mother.UpdateUser.Country));
        }

        //[Test]
        //[Order(3)]
        //public async Task UpdateUserGroupShouldReturnOk()
        //{
        //    var jsonObject = new JsonPatchDocument<PatchUsuarioDTO>();
        //    jsonObject.Replace(jo => jo.Activo, true);
        //    var request = new HttpRequestMessage(HttpMethod.Patch, $"{_uri}/{_userId}")
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(jsonObject), System.Text.Encoding.Unicode, "application/json")
        //    };
        //    var actual = await _sut.SendAsync(request);
        //    Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
        //}

    }
}
