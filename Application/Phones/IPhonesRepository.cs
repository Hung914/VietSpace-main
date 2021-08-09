using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Domain;

namespace Application.Phones
{
    public interface IPhonesRepository
    {

        Task<List<PhoneDto>> GetPhonesAsync();
        Task<PhoneDto> GetPhoneAsync(Guid id);
        Task CreatePhoneAsync(Phone phone);
        Task UpdatePhoneAsync(Phone phone);
        Task DeletePhoneAsync(Guid id);

    
    }
}