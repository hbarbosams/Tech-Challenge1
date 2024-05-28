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
    [InlineData("+1 (123) 456-7890", false)]  
    [InlineData("123-45-6789", true)]       
    [InlineData("1234567890123456", false)]  
    [InlineData("abc-456-7890", false)]     
    [InlineData("", false)]                  
    [InlineData(null, false)]                
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
