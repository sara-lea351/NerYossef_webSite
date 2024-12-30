using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Repositories
{
    public interface IAlertRepository
    {

        Task<List<Alert>> GetAlerts();

        Task<Alert?> GetAlertByID(int alertId);

        Task<List<Alert?>> GetAlertByPersonID(int personId);

        Task<Alert?> UpdateAlertStatus(int statusId, Alert newAlert);

        Task<bool> Delete(int documentTypeId);

    }
}
