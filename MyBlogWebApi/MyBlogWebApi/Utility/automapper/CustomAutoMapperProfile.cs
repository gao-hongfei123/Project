using AutoMapper;
using MyBlog.Model;
using MyBlog.Model.DTO;

namespace MyBlogWebApi.Utility.automapper
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            
            CreateMap<Writer,WriterDto>();
            CreateMap<BlogNews, BlogNewsDTO>();
        }
    }
}
