using System;
using Domain.Enums;

namespace Domain.Models.Customer
{
    public class CustomerRequestModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Document { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
