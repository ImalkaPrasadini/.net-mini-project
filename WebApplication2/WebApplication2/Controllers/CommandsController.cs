using AutoMapper;
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

        [HttpGet("id")]
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



    }
}
