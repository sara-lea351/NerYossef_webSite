using NerYossefWebsite.DTO_s;

namespace NerYossefWebsite.Services
{
    public interface IKollelService
    {
        Task<List<kollelDTO>> GetKollelmen();
        Task<kollelDTO?> GetKollelmanById(int id);
        Task<kollelWithDocumentsDTO> CreateKollelman(kollelWithDocumentsDTO kollelmanDto);
        Task<kollelDTO?> Update(int kollelmanId, kollelDTO kollelmanDto);
        Task<bool> Delete(int kollelmanId);
    }
}
