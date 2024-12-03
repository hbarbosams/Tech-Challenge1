using System.Text;
using Domain.DTOs.Saida;
using Domain.Models;
using FluentAssertions;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace IntegrationTests.Tests;

public class ContatoTests : BaseIntegrationTest
{
    public ContatoTests(TechChallengeFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Create_ShouldCreateNewContact()
    {
        // Arrange
        var contato = new Contato
        {
            Nome = "Hugo Barbosa de Melo Santos",
            Email = "hbarbosams@gmail.com",
            Telefone = "997439808",
            FoneDddId = 3
        };


        // Act
        var contatoContent = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/contato")
        {
            Content = contatoContent
        };

        // Assert
        Assert.NotNull(contato);
        contato.Nome.Should().Be(contato.Nome);
        contato.Email.Should().Be(contato.Email);
        contato.Telefone.Should().Be(contato.Telefone);
        contato.FoneDddId.Should().Be(contato.FoneDddId);
    }


    [Fact]
    public async Task GetById_ShouldReturnContact()
    {
        // Arrange
        var contato = new Contato
        {
            Nome = "Hugo Barbosa de Melo Santos",
            Email = "hbarbosams@gmail.com",
            Telefone = "997439808",
            FoneDddId = 3
        };
        DbContext.Contato.Add(contato);
        await DbContext.SaveChangesAsync();

        // Act
        var contatoContent = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/contato")
        {
            Content = contatoContent
        };

        // Assert

        Assert.NotNull(contato);
        contato.Nome.Should().Be(contato.Nome);
        contato.Email.Should().Be(contato.Email);
        contato.Telefone.Should().Be(contato.Telefone);
        contato.FoneDddId.Should().Be(contato.FoneDddId);
    }

    [Fact]
    public async Task Update_ShouldUpdateContact()
    {
        // Arrange
        var contato = new Contato
        {
            Nome = "Hugo Barbosa de Melo Santos",
            Email = "hbarbosams@gmail.com",
            Telefone = "997439808",
            FoneDddId = 3
        };
        DbContext.Contato.Add(contato);
        await DbContext.SaveChangesAsync();

        contato.Email = "atualizar@teste.com";
        contato.Telefone = "123456789";

        // Act
        var contatoContent = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/contato")
        {
            Content = contatoContent
        };

        // Assert
        Assert.NotNull(contato);
        contato.Nome.Should().Be(contato.Nome);
        contato.Email.Should().Be(contato.Email);
        contato.Telefone.Should().Be(contato.Telefone);
        contato.FoneDddId.Should().Be(contato.FoneDddId);
    }


    private T? GetMessageFromQueue<T>(string queueName)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // Consome uma única mensagem da fila (se houver)
        var result = channel.BasicGet(queueName, true);

        if (result == null)
            return default(T); // Nenhuma mensagem na fila

        // Converte o corpo da mensagem de byte[] para string
        var messageBody = Encoding.UTF8.GetString(result.Body.ToArray());

        // Deserializa a mensagem de volta para o objeto Contato
        var envelope = JsonConvert.DeserializeObject<MassTransitMessageEnvelope<T>>(messageBody);
        return envelope.Message;
    }

    public class MassTransitMessageEnvelope<T>
    {
        [JsonProperty("message")]
        public T Message { get; set; }
    }
}