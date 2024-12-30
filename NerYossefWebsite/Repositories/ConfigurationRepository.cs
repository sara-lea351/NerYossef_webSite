using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {

        private readonly NerYossefDbContext _ConfigurationContext;

        public ConfigurationRepository(NerYossefDbContext ConfigurationContext)
        {
            _ConfigurationContext = ConfigurationContext;
        }


        public async Task<List<Configuration>> GetConfigurations()
        {
            return await _ConfigurationContext.Configurations.ToListAsync();
        }

        public async Task<Configuration?> GetConfigurationByID(int configurationId)
        {
            return await _ConfigurationContext.Configurations
                .FirstOrDefaultAsync(s => s.ConfigurationId == configurationId);
        }

        public async Task<Configuration?> CreateConfiguration(Configuration configuration)
        {
            _ConfigurationContext.Configurations.Add(configuration);
            await _ConfigurationContext.SaveChangesAsync();
            return configuration;
        }

        public async Task<Configuration?> UpdateConfiguration(int configurationId, Configuration configuration)
        {
            var existingConfiguration = await _ConfigurationContext.Configurations
                .FirstOrDefaultAsync(s => s.ConfigurationId == configurationId);

            if (existingConfiguration == null)
            {
                return null;
            }

            existingConfiguration.Value = configuration.Value;
            existingConfiguration.KeyName = configuration.KeyName;
            existingConfiguration.Description = configuration.Description;


            await _ConfigurationContext.SaveChangesAsync();
            return configuration; 
        }

        public async Task<bool> Delete(int configurationId)
        {
            var configuration = await _ConfigurationContext.Configurations
                .FirstOrDefaultAsync(s => s.ConfigurationId == configurationId);

            if (configuration == null)
            {
                return false;
            }

            _ConfigurationContext.Configurations.Remove(configuration);
            await _ConfigurationContext.SaveChangesAsync();
            return true;
        }
    }
}

