using System;

namespace Domain
{
    public class Phone
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Description { get; set; }
        public Guid BusinessId{get; set;}
    }


    public enum PhoneType
    {
        Mobile,
        Landline
    }
}