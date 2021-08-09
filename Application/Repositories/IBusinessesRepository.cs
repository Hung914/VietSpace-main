using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Businesses;
using Domain;

namespace Application.Repositories
{
    public interface IBusinessesRepository
    {
        Task<BusinessDto> GetBusinessAsync(Guid id);
        Task<List<BusinessDto>> GetBusinessesAsync();
        Task CreateBusinessAsync(Business business);
        Task UpdateBusinessAsync(BusinessDto business);
        Task DeleteBusinessAsync(Guid id);
        // Task UpdateBusinessAsync(BusinessDto business);
        // Task DeleteBusinessAsync(Business business);
        Task<bool> AddPhotoAsync(Guid bussinessId, Photo photo);
        Task<bool> DeletePhotoAsync(string photoId);
    }
}