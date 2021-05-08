using Api.Personal.Views;
using Application.Resources;

namespace AutoMapper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            this.CreateMap<PersonalDetailsResource, PersonalDetailsViewModel>();
        }
    }
}