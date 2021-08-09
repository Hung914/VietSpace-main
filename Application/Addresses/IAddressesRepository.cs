using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Domain;

namespace Application.Addresses
{
    public interface IAddressesRepository
    {
        Task<List<AddressDto>> GetAddressesAsync();
        Task<AddressDto> GetAddressAsync(Guid id);
        Task CreateAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(Guid id);        
        
    }
}