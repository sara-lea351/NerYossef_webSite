using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Services.ServiceValidations
{
    public class groupMemberValidation
    {
        public void validate(groupMemberDTO groupMemberDto)
        {
            if (!generalValidation.IsValidEmail(groupMemberDto.Email))
                throw new ArgumentException("מייל התלמיד אינו תקין.");

            if (!generalValidation.IsValidPhoneNumber(groupMemberDto.Phone))
                throw new ArgumentException("פלאפון התלמיד אינו תקין.");

        }
    }
}
