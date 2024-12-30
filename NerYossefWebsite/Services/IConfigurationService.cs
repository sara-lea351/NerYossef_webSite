using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Services
{
    public interface IConfigurationService
    {

        Task<List<Configuration>> GetConfigurations();

        Task<Configuration?> GetConfigurationByID(int configurationId);

        Task<Configuration?> CreateConfiguration(Configuration configuration);
        Task<Configuration?> UpdateConfiguration(int configurationiD, Configuration newConfiguration);

        Task<bool> Delete(int configurationId);
    }
}
