using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Test.Admin
{
    internal class UserControllerTest: TestBase
    {
        private readonly string _uri = "api/users";

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
    }
}
