using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Database.Services.Interfaces;
using Models.Requests;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests.Api
{
    public class InmateCrudControllerTests : IClassFixture<TestApiFactory>
    {
        public InmateCrudControllerTests(TestApiFactory apiFactory)
        {
            _apiFactory = apiFactory;
        }

        private readonly TestApiFactory _apiFactory;
        private readonly Mock<IInmateCrudService> _mockCrudService = new Mock<IInmateCrudService>();

        private static ByteArrayContent ConvertObjectToJsonBytes(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        [Fact]
        public async Task UpdateInmateWorksCorrectly()
        {
            var request = new InmateUpdateRequest
            {
                Name = "Fake Name"
            };

            _mockCrudService.Setup(x => x.UpdateInmate(request)).Returns(Task.CompletedTask);

            var servicesToInject = new List<(Type InterfaceToMatch, object Implementation)>
            {
                (typeof(IInmateCrudService), _mockCrudService.Object)
            };
            var fakeApi = _apiFactory.BuildClient(servicesToInject);

            var byteContent = ConvertObjectToJsonBytes(request);
            var endpoint = "api/InmateCrud/UpdateInmate";

            var response = await fakeApi.PatchAsync(endpoint, byteContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}