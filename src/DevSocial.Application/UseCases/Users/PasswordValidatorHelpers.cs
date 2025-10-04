using System.Text.RegularExpressions;

namespace DevSocial.Application.UseCases.Users;

public static partial class PasswordValidatorHelpers
{
    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseLetter() ;
}