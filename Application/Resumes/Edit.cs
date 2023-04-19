using System.Diagnostics;
using System.Net;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Resumes
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>{
            public Resume Resume{ get; set;}
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
            public DataContext _context { get; }
            private readonly IMapper _mapper ;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
               var resume = await _context.Resumes.FindAsync(request.Resume.Id);
                if (resume == null) return null;

                _mapper.Map(request.Resume, resume);

                var result = await _context.SaveChangesAsync() > 0;

                if(!result){
                    return Result<Unit>.Failure("Failed to update activity");
                }
               return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}