using AutoFixture;
using Domain.Models;
using Service.Helpers;

namespace UnitTests;

public class PhoneNumberValidatorTests
{
    [Theory]
    [InlineData("123-456-7890", true)]
    [InlineData("(123) 456-7890", true)]
    [InlineData("123 456 7890", true)]
    [InlineData("1234567890", true)]
    [InlineData("+1 (123) 456-7890", false)]  // Exemplo com código de país
    [InlineData("123-45-6789", false)]       // Menos dígitos
    [InlineData("123456789012345", true)]    // Máximo de dígitos permitido
    [InlineData("1234567890123456", false)]  // Mais dígitos que o permitido
    [InlineData("abc-456-7890", false)]      // Contém letras
    [InlineData("", false)]                  // String vazia
    [InlineData(null, false)]                // Null
    public void IsValidPhoneNumber_ValidatesCorrectly(string phoneNumber, bool expectedResult)
    {
        // Act
        var contato = new Fixture().Create<Contato>();
        contato.Telefone = phoneNumber;

        var result = contato.Telefone.IsValidPhoneNumber();

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
