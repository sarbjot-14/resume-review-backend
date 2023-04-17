using System.Diagnostics;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> EditResume(Guid id, Resume resume){

            resume.Id = id;

            return Ok(await Mediator.Send(new Edit.Command{Resume = resume}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResume(Guid id){
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}