using FluentValidation;
using FluentValidation.Validators;
using StudentLibrary.Models;

namespace StudentLibrary.Validations;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(student => student.StudentNumber).NotEmpty().Length(6);
        RuleFor(student => student.FirstName).NotEmpty().Length(3, 50);
        RuleFor(student => student.LastName).NotEmpty().Length(3, 50);
        RuleFor(student => student.PhoneNo).NotEmpty().Length(11).WithMessage("Invalid phone number");
        RuleFor(student => student.EmailAddress).EmailAddress(EmailValidationMode.Net4xRegex).Length(3, 50);
    }
}
