using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace NerYossefWebsite.Services.ServiceValidations
{
    public class generalValidation
    {

        private static readonly Regex PhoneRegex = new Regex(
            @"^\+?\d+$", // אפשרות לסימן + בתחילת המספר, ואחריו רק ספרות
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValidEmail(string email)
        {
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(email);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return PhoneRegex.IsMatch(phoneNumber);
        }

        public static bool ValidateIsraeliId(string idNumber)
        {
            return Regex.IsMatch(idNumber, @"^\d{9}$");
        }

        public static bool ValidateFrenchPassport(string passportNumber)
        {
            return Regex.IsMatch(passportNumber, @"^[A-Z]{2}\d{7}[A-Z]{2}$");
        }
    }
}
