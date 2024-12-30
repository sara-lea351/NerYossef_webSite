using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Services.ServiceValidations
{
    public class kollelValidation
    {
        private string[] typeOptions = ["חצי יום", "אברך"];
        public void validate(kollelDTO kollelman)
        {
            if (!generalValidation.IsValidEmail(kollelman.Email))
                throw new ArgumentException("מייל האברך אינו תקין.");

            if (!generalValidation.IsValidPhoneNumber(kollelman.Phone))
                throw new ArgumentException("פלאפון האברך אינו תקין.");

            if (kollelman.NumberId != null && !generalValidation.ValidateIsraeliId(kollelman.NumberId) || kollelman.PassportNumber != null && !generalValidation.ValidateFrenchPassport(kollelman.PassportNumber))
                throw new ArgumentException("מספר הזהות אינו תקין");

            if (kollelman.NumberId == null && kollelman.PassportNumber == null)
                throw new ArgumentException("חובה להזין מספר דרכון או מספר זהות");

            if (!typeOptions.Contains(kollelman.PersonType))
                throw new ArgumentException("חובה להזין אברך או חצי יום");
        }
    }
}
