namespace Service.Helpers;

public static class TextValidator
{
    public static bool IsValidTextLength(this string text, int minLength, int maxLength)
    {
        if (text == null)
            return false;

        int length = text.Length;
        return length >= minLength && length <= maxLength;
    }
}
