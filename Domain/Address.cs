using System;

namespace Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public Guid BusinessId {get; set;}
    }
}