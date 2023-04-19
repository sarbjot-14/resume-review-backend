
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Resumes
{
    public class List
    {
        public class Query : IRequest<Result<List<Resume>>> {}

        public class Handler : IRequestHandler<Query, Result<List<Resume>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _logger = logger;
                _context = context;
            }

            public async Task<Result<List<Resume>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                return Result<List<Resume>>.Success(await _context.Resumes.ToListAsync());
            }
        }
    }
}