using Newtonsoft.Json;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DeleteSpecificTodoTodoWithExistentId()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("todos/1", Method.Delete);
            var queryResult = client.Execute(request);

            Assert.Equal(System.Net.HttpStatusCode.OK, queryResult.StatusCode);

        }

    }
}
