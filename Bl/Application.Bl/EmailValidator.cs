using Application.Bl.Contracts;
using System.Text.RegularExpressions;

namespace Application.Bl
{
    public class EmailValidator : IEmailValidator
    {
        private static Regex _validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

        public bool IsValid(string email)
        {
            return _validateEmailRegex.IsMatch(email);
        }
    }
}