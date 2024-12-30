using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class KollelService:IKollelService
    {
        private IKollelRepository _kollelRepository;
        private kollelValidation _kollelValidation;
        public KollelService(IKollelRepository kollelRepository, kollelValidation kollelValidation)
        {
            _kollelRepository = kollelRepository;
            _kollelValidation = kollelValidation;
        }

        public async Task<List<kollelDTO>> GetKollelmen()
        {
            return await _kollelRepository.GetKollelmen();
        }

        public async Task<kollelDTO?> GetKollelmanById(int id)
        {
            return await _kollelRepository.GetKollelmanById(id);
        }

        public async Task<kollelWithDocumentsDTO> CreateKollelman(kollelWithDocumentsDTO kollelmanDto)
        {
            _kollelValidation.validate(kollelmanDto);
            return await _kollelRepository.CreateKollelman(kollelmanDto);
        }

        public async Task<kollelDTO?> Update(int kollelmanId, kollelDTO kollelmanDto)
        {
            _kollelValidation.validate(kollelmanDto);
            return await _kollelRepository.Update(kollelmanId, kollelmanDto);
        }

        public async Task<bool> Delete(int kollelmanId)
        {
            return await _kollelRepository.Delete(kollelmanId);
        }
    }
}
