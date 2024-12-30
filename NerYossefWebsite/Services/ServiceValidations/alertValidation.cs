using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Services.ServiceValidations
{
    public class alertValidation
    {
        private string[] statusOptions = ["סגור", "בטיפול", "חדש"];

        public bool validateStatus(alertDTO alert)
        {
            if (!statusOptions.Contains(alert.AlertStatus))
                throw new ArgumentException("סטטוס המשימה אינו תקין");

            return true;
        }

        public void validateAlert(alertDTO alert)
        {
            this.validateStatus(alert);
        }
    }
}
