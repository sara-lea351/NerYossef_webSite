
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Services.ServiceValidations
{
    public class studentValidation
    {
        private string[] classOptions = ["בוגר", "שיעור ג", "שיעור ב", "שיעור א"];
        private string[] paymentOptions = ["הוראת קבע", "מזומן", "אשראי"];
        public void validate(studentDTO student) 
        { 
            if(!generalValidation.IsValidEmail(student.Email))
                throw new ArgumentException("מייל התלמיד אינו תקין.");

            if (!generalValidation.IsValidEmail(student.FatherMail) || !generalValidation.IsValidEmail(student.MotherMail))
                throw new ArgumentException("מייל ההורים אינו תקין.");

            if (!generalValidation.IsValidPhoneNumber(student.Phone))
                throw new ArgumentException("פלאפון התלמיד אינו תקין.");
            
            if (!generalValidation.IsValidPhoneNumber(student.FatherPhone) || !generalValidation.IsValidPhoneNumber(student.MotherPhone))
                throw new ArgumentException("פלאפון ההורים אינו תקין.");
            
            if(student.NumberId != null && !generalValidation.ValidateIsraeliId(student.NumberId) || student.PassportNumber != null && !generalValidation.ValidateFrenchPassport(student.PassportNumber))
                throw new ArgumentException("מספר הזהות אינו תקין");

            if (student.NumberId == null && student.PassportNumber == null)
                throw new ArgumentException("חובה להזין מספר דרכון או מספר זהות");

            if (student.PersonType != "תלמיד")
                throw new ArgumentException("חובה לסווג תלמיד להיות מסוג תלמיד");

            if (!classOptions.Contains(student.Class))
                throw new ArgumentException("שכבת התלמיד אינה תקינה");

            if (student.Class == "בוגר" && student.ExitDate == null)
                throw new ArgumentException("חובה להזין תאריך יציאה מהישיבה עבור תלמיד בוגר");

            if (!paymentOptions.Contains(student.Payment))
                throw new ArgumentException("אופן התשלום אינו תקין");
            
        }
    }
}
