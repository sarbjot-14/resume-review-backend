
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Resumes
{
    public class Create : IRequest
    {
        public class Command : IRequest<Result<Unit>>{
            public Resume Resume {get;set;}
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x=> x.Resume).SetValidator(new ResumeValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Resumes.Add(request.Resume);

                var result = await _context.SaveChangesAsync() > 0;
                
                if(!result){
                    return Result<Unit>.Failure("Failed to create resume");
                }

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}