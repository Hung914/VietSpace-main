using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Dtos;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Addresses
{
    public class EfCoreAddressesRepository : IAddressesRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EfCoreAddressesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AddressDto>> GetAddressesAsync()
        {
            var addresses = await _context.Addresses
                .ToListAsync();
            return _mapper.Map<List<Address>, List<AddressDto>>(addresses);
        }

        public async Task<AddressDto> GetAddressAsync(Guid id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if(address is null)
            {
                throw new NotFoundException("Address not found"); 
            }
            var addressToReturn = _mapper.Map<Address, AddressDto>(address); 
            return addressToReturn;
        }

        public async Task CreateAddressAsync(Address address)
        {
            var addressToAdd = new Address
            {
                Id = address.Id,
                Street = address.Street,
                Suburb = address.Suburb,
                State = address.State,
                PostCode = address.PostCode,
                BusinessId = address.BusinessId
                
            };
            await _context.Addresses.AddAsync(addressToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            if(address is null) throw new NotFoundException("address not found");
            var addressToUpdate = await _context.Addresses.FindAsync(address.Id);
            if(addressToUpdate is null) throw new NotFoundException("address not found"); 
            _mapper.Map(address, addressToUpdate);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAddressAsync(Guid id)
        {
            var addressToDelete = await _context.Addresses.FindAsync(id);
            if(addressToDelete is null) throw new NotFoundException("address not found");
            if(id == null) throw new NotFoundException("address not found");
            _context.Remove(addressToDelete);
            await _context.SaveChangesAsync();
        }
       
        
    }
}