using Api.Personal.Views;
using Application.Resources;
using AutoMapper;

namespace Api
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            this.CreateMap<PersonalDetailsResource, PersonalDetailsViewModel>();
        }
    }
}