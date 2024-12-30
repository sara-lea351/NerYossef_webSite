using AutoMapper;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {

        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<documentTypeDTO>> GetDocumentTypes()
        {
            var documentTypes = await _documentTypeRepository.GetDocumentTypes();
            return _mapper.Map<List<documentTypeDTO>>(documentTypes);
        }

        public async Task<documentTypeDTO?> GetDocumentTypeByID(int documentTypeId)
        {
            var documentType = await _documentTypeRepository.GetDocumentTypeByID(documentTypeId);
            return _mapper.Map<documentTypeDTO>(documentType);
        }

        public async Task<documentTypeDTO> CreateDocumentType(documentTypeDTO documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            var createdDocumentType = await _documentTypeRepository.CreateDocumentType(documentType);
            return _mapper.Map<documentTypeDTO>(createdDocumentType);
        }

        public async Task<documentTypeDTO?> UpdateDocumentType(int documentTypeId, documentTypeDTO documentTypeDto)
        {
            var documentType = await _documentTypeRepository.UpdateDocumentType(documentTypeId, _mapper.Map<DocumentType>(documentTypeDto));
            return _mapper.Map<documentTypeDTO>(documentType);
        }

        public async Task<bool> Delete(int documentTypeId)
        {
            return await _documentTypeRepository.Delete(documentTypeId);
        }

        //private IDocumentTypeRepository _documentTypeRepository;

        //public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        //{
        //    _documentTypeRepository = documentTypeRepository;
        //}


        //public async Task<List<documentTypeDTO>> GetDocumentTypes()
        //{
        //    return await _documentTypeRepository.GetDocumentTypes();
        //}    

        //public async Task<documentTypeDTO?> GetDocumentTypeByID(int documentTypeId)
        //{
        //    return await _documentTypeRepository.GetDocumentTypeByID(documentTypeId);
        //}  

        //public async Task<documentTypeDTO> CreateDocumentType(documentTypeDTO documentTypeDto)
        //{
        //    return await _documentTypeRepository.CreateDocumentType(documentTypeDto);
        //}

        //public async Task<documentTypeDTO?> UpdateDocumentType(int documentTypeId, documentTypeDTO documentTypeDto)
        //{
        //    return await _documentTypeRepository.UpdateDocumentType(documentTypeId, documentTypeDto);
        //}

        //public async Task<bool> Delete(int documentTypeId)
        //{
        //    return await _documentTypeRepository.Delete(documentTypeId);
        //}
    }
}
