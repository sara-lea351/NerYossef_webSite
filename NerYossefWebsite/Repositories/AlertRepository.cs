using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class AlertRepository : IAlertRepository
    {

        private readonly NerYossefDbContext _AlertContext;

        public AlertRepository(NerYossefDbContext AlertContext)
        {
            _AlertContext = AlertContext;
        }


        public async Task<List<Alert>> GetAlerts()
        {
            return await _AlertContext.Alerts.ToListAsync();
        }

        public async Task<Alert?> GetAlertByID(int alertId)
        {
            return await _AlertContext.Alerts
                .FirstOrDefaultAsync(s => s.AlertId == alertId);
        }

        public async Task<List<Alert?>> GetAlertByPersonID(int personId)
        {
            return await (from alert in _AlertContext.Alerts
                                where alert.PersonId == personId
                                select alert).ToListAsync();
        }
        
        public async Task<Alert?> UpdateAlertStatus(int alertId, Alert alert)
        {
            var existingAlert = await _AlertContext.Alerts
                .FirstOrDefaultAsync(s => s.AlertId == alertId);

            if (existingAlert == null)
            {
                return null;
            }

            existingAlert.AlertStatus = alert.AlertStatus;
            existingAlert.CompletionDate = alert.CompletionDate;

            await _AlertContext.SaveChangesAsync();
            return alert; 
        }

        public async Task<bool> Delete(int alertId)
        {
            var alert = await _AlertContext.Alerts
                .FirstOrDefaultAsync(s => s.AlertId == alertId);

            if (alert == null)
            {
                return false;
            }

            _AlertContext.Alerts.Remove(alert);
            await _AlertContext.SaveChangesAsync();
            return true;
        }
    }
}

