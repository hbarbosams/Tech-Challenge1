using System.Text.RegularExpressions;

namespace Service.Helpers;

public static class PhoneNumberValidator
{
    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            return false;
        }

        // Remove espaços, hífens e parênteses
        string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");

        // Verifica se contém apenas dígitos e tem um tamanho de 9 (ajuste conforme necessário)
        return Regex.IsMatch(cleanedPhoneNumber, @"^\d{8,10}$");
    }
}
