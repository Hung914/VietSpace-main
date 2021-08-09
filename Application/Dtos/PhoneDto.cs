using System;

namespace Application.Dtos
{
    public class PhoneDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public PhoneTypeDto PhoneType { get; set; }
        public string Description { get; set; }
        public Guid BusinessId{get; set;}
    }


    public enum PhoneTypeDto
    {
        Mobile,
        Landline
    }
}