using AutoMapper;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class CommandsProfile: Profile
    {
        public CommandsProfile() 
        {
            CreateMap<Command, CommandReadDto>();
        }
    }
}
