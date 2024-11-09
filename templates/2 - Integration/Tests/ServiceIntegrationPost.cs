﻿using Newtonsoft.Json;
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
        public void PostSpecificTodoWithExistentId()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("todos", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new TodoModel
            {
                UserId = 1,
                Id = 1,
                Title = "Test Post",
                Completed = false
            });
            var queryResult = client.Execute(request);

            TodoModel todo = JsonConvert.DeserializeObject<TodoModel>(queryResult.Content);

            Assert.Equal(System.Net.HttpStatusCode.Created, queryResult.StatusCode);
            Assert.Equal(201, todo.Id);
            Assert.Equal(1, todo.UserId);
            Assert.Equal("Test Post", todo.Title);
            Assert.Equal(false, todo.Completed);

        }

    }
}
