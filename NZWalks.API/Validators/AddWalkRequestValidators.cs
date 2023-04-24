using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public class AddWalkRequestValidators : AbstractValidator<AddWalkRequestDto>
    {
        public AddWalkRequestValidators()
        {
            RuleFor(x => x.Name).Length(5,8)
                .WithMessage("not more than 8 character");

            RuleFor(x => x.Description).Length(0,10)
                .WithMessage("no longer than 10 words ");

            RuleFor(x => x.LengthInKm).InclusiveBetween(0,10)
                .WithMessage("not more than 10 km");

            RuleFor(x => x.WalkImageUrl).NotEmpty()
                .WithMessage("dena jaruri nahi hai");

            RuleFor(x => x.DifficultyId).NotEmpty()
                .WithMessage("bhejo please isse jarur bheo ");

            RuleFor(x => x.RegionID).NotEmpty()
                .WithMessage("Region Id bhejna bht jarui hai ");

        }
    }
}
