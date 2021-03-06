﻿using NUnit.Framework;
using System.Net.Http;

namespace GeJu.Api.Main.Test
{
    internal class TestBase
    {
        protected MainApiWebApplicationFactory _factory;
        protected HttpClient _sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _factory = new MainApiWebApplicationFactory();
            _sut = _factory.CreateClient();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _sut.Dispose();
            _factory.Dispose();
        }
    }
}
