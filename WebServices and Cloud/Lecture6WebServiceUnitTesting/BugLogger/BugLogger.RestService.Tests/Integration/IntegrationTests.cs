using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Data.Repositories;
using BugLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace BugLogger.RestService.Tests.Integration
{

    [TestClass]
    public class IntegrationTests
    {
        private static Random rand = new Random();
        private string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void GetAll_WhenBugsInDb_ShouldReturnStatus200AndNonEmptyContent()
        {
            IGenericRepository<Bug> repo = Mock.Create<IGenericRepository<Bug>>();
            Bug[] bugs = { new Bug(), new Bug(), new Bug() };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreateGetRequest("/api/bugs");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsValid_ShouldReturn201AndLocationHeader()
        {
            IGenericRepository<Bug> repo = Mock.Create<IGenericRepository<Bug>>();

            Bug bug = GetValidBug();

            Mock.Arrange(() => repo.Add(Arg.IsAny<Bug>()));

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsEmpty_ShouldReturn400()
        {
            IGenericRepository<Bug> repo = Mock.Create<IGenericRepository<Bug>>();

            Bug bug = new Bug()
            {
                Text = ""
            };

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsNull_ShouldReturn400()
        {
            IGenericRepository<Bug> repo = Mock.Create<IGenericRepository<Bug>>();

            Bug bug = new Bug()
            {
                Text = null
            };

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }



        private Bug GetValidBug()
        {
            return new Bug()
            {
                Id = rand.Next(1000, 2000),
                Text = "New Bug #" + rand.Next(1000, 2000)
            };
        }
    }
}
