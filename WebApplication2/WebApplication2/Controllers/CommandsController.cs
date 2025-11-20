using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {

            _commanderRepo = repository;
            _mapper = mapper;

        }
        //private readonly MockCommanderRepo _commanderRepo = new MockCommanderRepo();

        [HttpGet]
        //public ActionResult<IEnumerable<Command>> GetAllCommands()
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {

            var commandItems = _commanderRepo.GetAppCommands();

            //return Ok(commandItems);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems ));
        }

        [HttpGet("id", Name = "GetCommandById")]
        public ActionResult<Command> GetCommandById(int id)
        {

            var commandItem = _commanderRepo.GetCommandById(id);

            if (commandItem != null)
            {


                //return Ok(commandItem);
                return Ok(_mapper.Map<CommandReadDto>(commandItem));

            } 
            return NotFound();
        }

        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _commanderRepo.CreateCommand(commandModel);
            _commanderRepo.saveChanges();

            var commandReadto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadto.Id }, commandReadto);
            //return Ok(commandReadto);
        }

        [HttpPut("id")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto) 
        {

            var commadModelFromRepo = _commanderRepo.GetCommandById(id);
            if (commadModelFromRepo == null) { 
            
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commadModelFromRepo);
            _commanderRepo.UpdateCommand(commadModelFromRepo);
            _commanderRepo.saveChanges();

            return NoContent();
        }
        [HttpPatch("id")]
        public ActionResult PartialCommadUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc) 
        {

            var commadModelFromRepo = _commanderRepo.GetCommandById(id);
            if (commadModelFromRepo == null)
            {

                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commadModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem();
            }

            _mapper.Map(commandToPatch, commadModelFromRepo);
            _commanderRepo.UpdateCommand(commadModelFromRepo);
            _commanderRepo.saveChanges();

            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult DeleteCommand(int id)
        {
            var commadModelFromRepo = _commanderRepo.GetCommandById(id);
            if (commadModelFromRepo == null)
            {

                return NotFound();
            }

            _commanderRepo.DeleteCommand(commadModelFromRepo);
            _commanderRepo.saveChanges();

            return NoContent();
        }

    }
}
