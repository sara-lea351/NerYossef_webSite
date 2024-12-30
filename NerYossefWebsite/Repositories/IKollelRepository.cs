using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public interface IKollelRepository
    {
        Task<List<kollelDTO>> GetKollelmen();
        Task<kollelDTO?> GetKollelmanById(int id);
        Task<kollelWithDocumentsDTO> CreateKollelman(kollelWithDocumentsDTO kollelmanDto);
        Task<kollelDTO?> Update(int kollelmanId, kollelDTO kollelmanDto);
        Task<bool> Delete(int kollelmanId);
    }
}
