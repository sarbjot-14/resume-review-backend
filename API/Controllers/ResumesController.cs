
using Application.Resumes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ResumesController :BaseApiController
    {
       

        [HttpGet]
        public async Task<ActionResult<List<Resume>>> GetResumes(){
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>> GetResume(Guid id){
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateResume(Resume resume){
            return Ok(await Mediator.Send(new Create.Command{Resume = resume}));
        }
    }
}