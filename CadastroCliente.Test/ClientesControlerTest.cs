using CadastroCliente.Business.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

//Optional
[assembly: CollectionBehavior(DisableTestParallelization = true)]
//Optional
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
//Optional
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]

namespace CadastroCliente.Test
{
    public class ClientesControlerTest
    {
        private readonly TestContext _testContext;
        private static Guid? Id = Guid.NewGuid();

        private static Cliente Cliente = new Cliente()
        {
            ClienteId = Id,
            Nome = "Nome Teste",
            Documento = 123456789,
            DataNascimento = DateTime.Now,
            Genero = "Masculino",
            Endereco = new Endereco()
            {
                Nome = "Casa",
                Rua = "Rua Teste",
                Numero = 123,
                Bairro = "Bairro Teste",
                Cidade = "Cidade Teste",
                Complemento = "Casa 1",
                Estado = "RJ"
                
            },
            Telefone = new Telefone()
            {
                Numero = 2345678,
                Tipo = "Celular"
            }
        };

        private readonly string Payload = JsonConvert.SerializeObject(Cliente);

        public ClientesControlerTest()
        {
            _testContext = new TestContext();
        }
                
        [Fact,Order(1)]
        public async Task Clientes_Post_ReturnsCreatedResponse()
        {
            var response = await _testContext.Client.PostAsync("/api/clientes", 
                new StringContent(Payload, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var cliente = JsonConvert.DeserializeObject<Cliente>(responseContent);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
       
        [Fact, Order(2)]
        public async Task Clientes_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/clientes");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
                
        [Fact, Order(2)]
        public async Task Clientes_GetById_ClientesReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/clientes/" + Id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, Order(2)]
        public async Task Clientes_GetById_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/clientes/ex");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, Order(3)]
        public async Task Clientes_Delete_ReturnsOKResponse()
        {
            var response = await _testContext.Client.DeleteAsync("/api/clientes/" + Id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
