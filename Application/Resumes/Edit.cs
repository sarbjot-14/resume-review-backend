using System.Diagnostics;
using System.Net;
using Domain;
using MediatR;
using Persistence;

namespace Application.Resumes
{
    public class Edit
    {
        public class Command : IRequest{
            public Resume Resume{ get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            public DataContext _context { get; }
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var resume = await _context.Resumes.FindAsync(request.Resume.Id);

               resume.Author = request.Resume.Author ?? resume.Author;

               await _context.SaveChangesAsync();

               return Unit.Value;
            }
        }
    }
}