using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Dtos;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Phones
{
    public class EfCorePhonesRepository: IPhonesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EfCorePhonesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PhoneDto>> GetPhonesAsync()
        {
            var phones = await _context.Phones
                .ToListAsync();
            return _mapper.Map<List<Phone>, List<PhoneDto>>(phones);
        }

        public async Task<PhoneDto> GetPhoneAsync(Guid id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if(phone is null)
            {
                throw new NotFoundException("Phone not found"); 
            }
            var phoneToReturn = _mapper.Map<Phone, PhoneDto>(phone); 
            return phoneToReturn;
        }

        public async Task CreatePhoneAsync(Phone phone)
        {
            var phoneToAdd = new Phone
            {
                Id = phone.Id,
                Number = phone.Number,
                PhoneType = phone.PhoneType,
                Description = phone.Description,
                BusinessId = phone.BusinessId
                
            };
            await _context.Phones.AddAsync(phoneToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhoneAsync(Phone phone)
        {
            if(phone is null) throw new NotFoundException("phone not found");
            var phoneToUpdate = await _context.Phones.FindAsync(phone.Id);
            if(phoneToUpdate is null) throw new NotFoundException("phone not found"); 
            _mapper.Map(phone, phoneToUpdate);

            await _context.SaveChangesAsync();

        }

        public async Task DeletePhoneAsync(Guid id)
        {
            var phoneToDelete = await _context.Phones.FindAsync(id);
            if(phoneToDelete is null) throw new NotFoundException("phone not found");
            if(id == null) throw new NotFoundException("phone not found");
            _context.Remove(phoneToDelete);
            await _context.SaveChangesAsync();
        }


    }
}