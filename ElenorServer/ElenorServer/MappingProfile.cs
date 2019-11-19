using Entities.Models;
using AutoMapper;
using Entities.DataTransferObjects.Message;
using Entities.DataTransferObjects;

namespace ElenorServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // For GET requests
            CreateMap<Message, MessageDto>();
            // For PUT requests
            CreateMap<MessageDto, Message>();
            // For POST requests
            CreateMap<MessageForCreationDto, Message>();
        }
    }
}
