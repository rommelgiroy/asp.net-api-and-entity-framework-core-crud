using FluentValidation;
using FluentValidation.Validators;
using StudentLibrary.Models;

namespace StudentLibrary.Validations;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(x => x.StudentNumber).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.PhoneNo).Length(11).NotEmpty();
        RuleFor(x => x.EmailAddress).EmailAddress();
    }
}
