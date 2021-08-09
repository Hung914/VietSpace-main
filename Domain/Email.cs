using System;

namespace Domain
{
    public class Email
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public Guid BusinessId{get; set;}
    }
}