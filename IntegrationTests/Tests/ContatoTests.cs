using System.Text;
using Domain.DTOs.Saida;
using Domain.Models;
using FluentAssertions;
using Newtonsoft.Json;

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
        var contatoContent = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

        // Act
        var httpRequest = await HttpClient.PostAsync("/api/contato", contatoContent);
        

        // Assert
        var requestContentString = await httpRequest.Content.ReadAsStringAsync();
        RespostaPadrao respostaPadrao = JsonConvert.DeserializeObject<RespostaPadrao>(requestContentString)!;
        Contato contatoCriado = JsonConvert.DeserializeObject<Contato>(JsonConvert.SerializeObject(respostaPadrao.Resposta))!;

        
        Assert.True(httpRequest.IsSuccessStatusCode);
        Assert.NotNull(contatoCriado);
        contatoCriado.Nome.Should().Be(contato.Nome);
        contatoCriado.Email.Should().Be(contato.Email);
        contatoCriado.Telefone.Should().Be(contato.Telefone);
        contatoCriado.FoneDddId.Should().Be(contato.FoneDddId);
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
        var httpRequest = await HttpClient.GetAsync($"/api/contato/{contato.Id}");
        

        // Assert
        var requestContentString = await httpRequest.Content.ReadAsStringAsync();
        RespostaPadrao respostaPadrao = JsonConvert.DeserializeObject<RespostaPadrao>(requestContentString)!;
        Contato contatoCriado = JsonConvert.DeserializeObject<Contato>(JsonConvert.SerializeObject(respostaPadrao.Resposta))!;

        
        Assert.True(httpRequest.IsSuccessStatusCode);
        Assert.NotNull(contatoCriado);
        contatoCriado.Nome.Should().Be(contato.Nome);
        contatoCriado.Email.Should().Be(contato.Email);
        contatoCriado.Telefone.Should().Be(contato.Telefone);
        contatoCriado.FoneDddId.Should().Be(contato.FoneDddId);
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
        var contatoContent = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

        // Act
        var httpRequest = await HttpClient.PutAsync("/api/contato", contatoContent);
        
         
        // Assert
        var requestContentString = await httpRequest.Content.ReadAsStringAsync();
        RespostaPadrao respostaPadrao = JsonConvert.DeserializeObject<RespostaPadrao>(requestContentString)!;
        Contato contatoCriado = JsonConvert.DeserializeObject<Contato>(JsonConvert.SerializeObject(respostaPadrao.Resposta))!;

        
        Assert.True(httpRequest.IsSuccessStatusCode);
        Assert.NotNull(contatoCriado);
        contatoCriado.Nome.Should().Be(contato.Nome);
        contatoCriado.Email.Should().Be(contato.Email);
        contatoCriado.Telefone.Should().Be(contato.Telefone);
        contatoCriado.FoneDddId.Should().Be(contato.FoneDddId);
    }
}