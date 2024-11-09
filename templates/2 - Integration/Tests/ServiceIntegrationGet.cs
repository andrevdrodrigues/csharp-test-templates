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
        public void GetSpecificTodoTodoWithExistentId()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("todos/1", Method.Get);
            var queryResult = client.Execute(request);

            TodoModel todo = JsonConvert.DeserializeObject<TodoModel>(queryResult.Content);

            Assert.Equal(System.Net.HttpStatusCode.OK, queryResult.StatusCode);
            Assert.Equal(1, todo.Id);
            Assert.Equal(1, todo.UserId);
            Assert.Equal("delectus aut autem", todo.Title);
            Assert.Equal(false, todo.Completed);

        }

    }
}
