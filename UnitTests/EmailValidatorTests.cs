using AutoFixture;
using Domain.Models;
using Service.Helpers;

namespace UnitTests;

public class EmailValidatorTests
{
    [Fact]
    public void IsValidEmail_ValidEmail_ReturnsTrue()
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Email = "example@gmail.com";

        // Act
        var result = contato.Email.IsEmailValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidEmail_EmptyEmail_ReturnsFalse()
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Email = "";

        // Act
        var result = contato.Email.IsEmailValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_EmailWithoutAtSymbol_ReturnsFalse()
    {
        // Arrange
        var contato = new Fixture().Create<Contato>();
        contato.Email = "examplegmail.com";

        // Act
        var result = contato.Email.IsEmailValid();

        // Assert
        Assert.False(result);
    }
}