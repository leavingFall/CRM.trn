using CRM.Web.DAL;
using FluentValidation;

namespace CRM.Web.Models
{
    public class AddressModelValidator : AbstractValidator<Address>
    {
        public AddressModelValidator()
        {
            RuleFor(o => o.Line1).NotEmpty().Length(4, 60);
            RuleFor(o => o.Line2).NotEmpty().Length(4, 60);
        }
    }
}