using System;
using System.Net.Http;
using API;
using Microsoft.AspNetCore.Mvc.Testing;
using Toggl;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace BookStore.IntegrationTest
{
    public class UnitTest1
    {
        private HttpClient _client;
        
        public void Unitest1()
        { 
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task Test1()
        {
           var response = await  _client.GetAsync(ApiRoutes.Posts.Get.Replace("{authorId}", "1"));
        }
    }
}