using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation;

public  class CarValidator : AbstractValidator<Car>

{
    public CarValidator()
    {
        RuleFor(c =>c.DailyPrice).NotEmpty();
        RuleFor(c => c.ColorId).GreaterThan(0);
        RuleFor(c =>c.BrandId).GreaterThan(0).When(c =>c.ModelYear>0);
        RuleFor(c => c.Description).MinimumLength(10);
        RuleFor(c => c.Description).Must(StartsWithA).WithMessage("Description A harfi ile başlamadır.");//kendim bir kral eklemek istediğimde must kullanırım.
    }

    private bool StartsWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}
