using AutoMapper;
using MyTodo3.Webapi3.Context;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Common
{
    public class AutoMapperExtentsion:MapperConfigurationExpression
    {
        public AutoMapperExtentsion()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<Memo, MemoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
