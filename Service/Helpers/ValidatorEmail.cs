using System.Text.RegularExpressions;

namespace Service.Helpers;

public static class ValidatorEmail
{
    public static bool IsEmailValid(this string email)
    {
        string strModel = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        
        return Regex.IsMatch(email, strModel);
    }
}
