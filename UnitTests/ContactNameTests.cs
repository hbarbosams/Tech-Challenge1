using AutoFixture;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Service.Helpers;

namespace UnitTests;

public class ContactNameTests
{
    [Fact]
    public void IsValidName_ValidName_ReturnsTrue()
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Nome = "João da Silva";

        // Act
        var result = !contato.Nome.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidName_EmptyName_ReturnsFalse()
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Nome = "";

        // Act
        var result = !contato.Nome.IsNullOrEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidName_NullName_ReturnsFalse()
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Nome = null;

        // Act
        var result = !contato.Nome.IsNullOrEmpty();

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("Ana", 5, 50, false)]
    [InlineData("José Ivaldo", 5, 50, true)]
    [InlineData("Sebastião da Silva Pereira", 5, 20, false)]
    [InlineData("", 1, 10, false)]
    [InlineData(null, 1, 10, false)]
    public void IsValidTextLength_ValidatesCorrectly(string text, int minLength, int maxLength, bool expectedResult)
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Nome = text;

        // Act
        var result = contato.Nome.IsValidTextLength(minLength, maxLength);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
