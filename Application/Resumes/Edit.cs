using System.Diagnostics;
using System.Net;
using AutoMapper;
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
            private readonly IMapper _mapper ;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var resume = await _context.Resumes.FindAsync(request.Resume.Id);

               //resume.Author = request.Resume.Author ?? resume.Author;
                _mapper.Map(request.Resume, resume);
               await _context.SaveChangesAsync();

               return Unit.Value;
            }
        }
    }
}