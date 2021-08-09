using System;
using System.Collections.Generic;
using Domain;

namespace Application.Dtos
{
    public class BusinessDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string Name { get; set; }

        //TODO: business type, enum or string (eg: Electrical, Plumbing, Restaurant etc...)
        //public string/enum  BusinessType { get; set; }
        public int CategoryId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }

        public List<Email> Emails { get; set; } = new();
        public List<Phone> Phones { get; set; } = new();
        public List<Photo> Photos {get; set;} = new();
        public List<Address> Addresses { get; set; } = new();
        public string Website { get; set; }   
        
        //TODO: Image url
        //public string LogoImageUrl { get; set; }
    // public string ImageUrlLowRes { get; set; }
    // public string ImageUrlHighRes { get; set; }
    
        //TODO: Opening hours
        
        public string Abn { get; set; }

        public BusinessDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
            UpdatedDate = DateTimeOffset.UtcNow;
        }
    }
}