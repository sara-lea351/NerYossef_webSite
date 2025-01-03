﻿using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public interface IStudentRepository
    {
        Task<List<studentDTO>> GetStudents();
        Task<studentDTO?> GetStudentById(int id);
        Task<studentWithDocumentDTO> CreateStudent(studentWithDocumentDTO studentDto);
        Task<studentDTO?> Update(int studentId, studentDTO studentDto);
        Task<bool> Delete(int studentId);

    }
}
