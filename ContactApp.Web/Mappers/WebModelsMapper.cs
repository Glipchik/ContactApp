using AutoMapper;
using ContactApp.Core.Entities;
using ContactApp.Web.Models;

namespace ContactApp.Web.Mappers
{
    public class WebModelsMapper : Profile
    {
        public WebModelsMapper()
        {
            CreateMap<Contact, CreateContactModel>().ReverseMap();
            CreateMap<Contact, UpdateContactModel>().ReverseMap();
        }
    }
}
