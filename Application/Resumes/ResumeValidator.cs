using System.Security.Cryptography.X509Certificates;


using Domain;
using FluentValidation;

namespace Application.Resumes
{
    public class ResumeValidator : AbstractValidator<Resume>
    {
        public ResumeValidator(){
            RuleFor(x=> x.Author).NotEmpty();
            RuleFor(x=> x.Date).NotEmpty();
            RuleFor(x=> x.Rating).NotEmpty();

        }
      
    }
}