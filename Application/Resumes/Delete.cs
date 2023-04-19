using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Resumes
{
    public class Delete
    {
        public class Command: IRequest<Result<Unit>>{
            public Guid Id {get;set;}
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
                var resume =  await _context.Resumes.FindAsync(request.Id);

                if(resume == null){
                    return null;
                }
                _context.Remove(resume);

               var result = await  _context.SaveChangesAsync() > 0 ;

               if(!result) return Result<Unit>.Failure("Failed to delete the resume");

               return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}