using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Dtos;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class EfCoreBusinessesRepository : IBusinessesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EfCoreBusinessesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BusinessDto> GetBusinessAsync(Guid id)
        {
            var business = await _context.Businesses
                                .Include(b => b.Emails)
                                .Include(b => b.Addresses)
                                .Include(b => b.Phones)
                                .Include(b =>b.Photos)
                                .SingleOrDefaultAsync(b => b.Id == id);
            if(business == null){
                throw new NotFoundException("Business not found");
            }
            var businessToReturn = _mapper.Map<Business, BusinessDto>(business);

            return businessToReturn;
        }

        public async Task<List<BusinessDto>> GetBusinessesAsync()
        {
            var businesses = await _context.Businesses
                .Include(b => b.Emails)
                .Include(b => b.Addresses)
                .Include(b => b.Phones)
                .Include(b => b.Photos)
                .ToListAsync();
            return _mapper.Map<List<Business>, List<BusinessDto>>(businesses);
        }

        public async Task CreateBusinessAsync(Business business)
        {
            var businessToAdd = new Business
            {
                Id = business.Id,
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow,
                Name = business.Name,
                CategoryId = business.CategoryId,
                Title = business.Title,
                Description = business.Description,
                Description2 = business.Description2,
                Description3 = business.Description3,
                Emails = business.Emails,
                Phones = business.Phones,
                Addresses = business.Addresses,
                Website = business.Website,
                Abn = business.Abn
            };
            await _context.Businesses.AddAsync(businessToAdd); 
            await _context.SaveChangesAsync();

        }

        public async Task UpdateBusinessAsync(BusinessDto business)
        {
            if (business is null) throw new NotFoundException("business not found");
            var businessToUpdate = await _context.Businesses.FindAsync(business.Id);
            if (businessToUpdate is null) throw new NotFoundException("business not found");
            _mapper.Map(business, businessToUpdate);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBusinessAsync(Guid id)
        {
            var businessToDelete = await _context.Businesses.FindAsync(id);
            var phoneToDelete =  await _context.Phones.Where(x => x.BusinessId == id).ToListAsync();
            var addressToDelete =  await _context.Addresses.Where(x => x.BusinessId == id).ToListAsync();
            var emailToDelete =  await _context.Emails.Where(x => x.BusinessId == id).ToListAsync();
            if (businessToDelete is null) throw new NotFoundException("business not found");

                        

            if (id == null) throw new NotFoundException("business not found");

            _context.Remove(businessToDelete);
            _context.RemoveRange(phoneToDelete);
            _context.RemoveRange(addressToDelete);
            _context.RemoveRange(emailToDelete);


            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddPhotoAsync(Guid bussinessId, Photo photo)
        {
            var business = await _context.Businesses.FindAsync(bussinessId);
            business.Photos.Add(photo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePhotoAsync(string photoId)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == photoId);
            if (photo == null) return true;

            _context.Photos.Remove(photo);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}