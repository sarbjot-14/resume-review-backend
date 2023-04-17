
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ResumesController :BaseApiController
    {
        public DataContext _context { get; }
    
        public ResumesController(DataContext context)
        {
            _context = context;
         
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Resume>>> GetResumes(){
            return await _context.Resumes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>> GetResume(Guid id){
            return await _context.Resumes.FindAsync(id);
        }
    }
}