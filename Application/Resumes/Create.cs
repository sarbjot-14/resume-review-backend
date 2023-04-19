
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Resumes
{
    public class Create : IRequest
    {
        public class Command : IRequest{
            public Resume Resume {get;set;}
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x=> x.Resume).SetValidator(new ResumeValidator());
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Resumes.Add(request.Resume);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}