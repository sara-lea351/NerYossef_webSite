using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Services
{
    public interface IAlertService
    {

        Task<List<alertDTO>> GetAlerts();

        Task<alertDTO?> GetAlertByID(int alertId);

        Task<List<alertDTO?>> GetAlertByPersonID(int personId);

        Task<alertDTO?> UpdateAlert(int statusId, alertDTO newAlert);

        Task<bool> Delete(int documentTypeId);
    }
}
