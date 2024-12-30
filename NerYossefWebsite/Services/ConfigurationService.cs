using AutoMapper;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class ConfigurationService : IConfigurationService
    {

        private readonly IConfigurationRepository _ConfigurationRepository;
        private readonly IMapper _mapper;

        public ConfigurationService(IConfigurationRepository ConfigurationRepository, IMapper mapper)
        {
            _ConfigurationRepository = ConfigurationRepository;
            _mapper = mapper;
        }

        public async Task<List<Configuration>> GetConfigurations()
        {
            return await _ConfigurationRepository.GetConfigurations();
        }

        public async Task<Configuration?> GetConfigurationByID(int configurationId)
        {
             return await _ConfigurationRepository.GetConfigurationByID(configurationId);
        }

        public async Task<Configuration?> CreateConfiguration(Configuration configuration)
        {
            return await _ConfigurationRepository.CreateConfiguration(configuration);
        }

        public async Task<Configuration?> UpdateConfiguration(int configurationId, Configuration configuration)
        {
            return await _ConfigurationRepository.UpdateConfiguration(configurationId, configuration);
        }

        public async Task<bool> Delete(int configurationId)
        {
            return await _ConfigurationRepository.Delete(configurationId);
        }

    }
}
