using CRM.Web.Models;
using FluentValidation.Attributes;

namespace CRM.Web.DAL
{
    [Validator(typeof(AddressModelValidator))]
    public class Address
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string ZipCode { get; set; }

        public string Post { get; set; }

        public Address()
        {
        }

        public Address(string line1, string line2, string zipCode, string post)
        {
            Line1 = line1;
            Line2 = line2;
            ZipCode = zipCode;
            Post = post;
        }
    }
}