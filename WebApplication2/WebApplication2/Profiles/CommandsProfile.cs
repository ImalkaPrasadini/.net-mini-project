using AutoMapper;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class CommandsProfile: Profile
    {
        public CommandsProfile() 
        {
            //source -> target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
