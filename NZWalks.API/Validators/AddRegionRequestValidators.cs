using FluentValidation;
using NZWalks.API.Helper;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public class AddRegionRequestValidators : AbstractValidator<AddRegionRequestDto>
    {
        public AddRegionRequestValidators()
        {
            RuleFor(x => x.Code).Length(0,3).WithMessage("Max Code length is 3");

            RuleFor(x => x.Name)
                .Length(4,10)
                .WithMessage("not more than 10 and less than 4")
                .Custom(CheckRegionName);
        }

        private static void CheckRegionName(string regionName, ValidationContext<AddRegionRequestDto> validationContext)
        {
            if (Utility.StringContainsNumeric(regionName))
            {
                validationContext.AddFailure($"Name cannot contain numeric digit.");
            }
        }
    }
}
