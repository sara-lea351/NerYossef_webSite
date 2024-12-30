using AutoMapper;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class AlertService : IAlertService
    {

        private readonly IAlertRepository _alertRepository;
        private alertValidation _alertValidation;
        private readonly IMapper _mapper;

        public AlertService(IAlertRepository alertRepository, alertValidation alertValidation, IMapper mapper)
        {
            _alertRepository = alertRepository;
            _alertValidation = alertValidation;
            _mapper = mapper;
        }

        public async Task<List<alertDTO>> GetAlerts()
        {
            var alerts = await _alertRepository.GetAlerts();
            return _mapper.Map<List<alertDTO>>(alerts);
        }

        public async Task<alertDTO?> GetAlertByID(int alertId)
        {
            var alert = await _alertRepository.GetAlertByID(alertId);
            return _mapper.Map<alertDTO?>(alert);
        }

        public async Task<List<alertDTO?>> GetAlertByPersonID(int personId)
        {
            var alerts = await _alertRepository.GetAlertByPersonID(personId);
            return _mapper.Map<List<alertDTO?>>(alerts);
        }

        public async Task<alertDTO?> UpdateAlert(int alertId, alertDTO alertDto)
        {
            _alertValidation.validateAlert(alertDto);

            if (alertDto.AlertStatus == "סגור" && !alertDto.CompletionDate.HasValue)
            {
                alertDto.CompletionDate = DateOnly.FromDateTime(DateTime.Now);
            }

            var alert = await _alertRepository.UpdateAlertStatus(alertId, _mapper.Map<Alert>(alertDto));
            return _mapper.Map<alertDTO>(alert);
        }

        public async Task<bool> Delete(int alertId)
        {
            return await _alertRepository.Delete(alertId);
        }

    }
}
