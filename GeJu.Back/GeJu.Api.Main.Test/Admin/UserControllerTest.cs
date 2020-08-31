using GeJu.Api.Main.DTO.Users;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Test.Admin
{
    internal class UserControllerTest: TestBase
    {
        private readonly string _uri = "api/users";
        private string _userId;

        [SetUp]
        public void SetUp()
        {
            _userId = "008b000c-210c-429c-a453-9653849ce0d7";
        }
        [Test]
        public async Task GetAllShouldReturnOk()
        {
            var response = await _sut.GetAsync(_uri);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
        }
        [Test]
        public async Task SaveShouldReturnOk()
        {
            var user = Mother.NewUserObject;
            var actual = await _sut.PostAsJsonAsync(_uri, user);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
        }
        [Test]
        public async Task UpdateUserGroupShouldReturnOk()
        {
            var jsonObject = new JsonPatchDocument<UserPatchDTO>();
            jsonObject.Replace(jo => jo.Action, true);
            var request = new HttpRequestMessage(HttpMethod.Patch, $"{_uri}/{_userId}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(jsonObject), System.Text.Encoding.Unicode, "application/json")
            };
            var actual = await _sut.SendAsync(request);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(actual.StatusCode));
        }
    }
}
