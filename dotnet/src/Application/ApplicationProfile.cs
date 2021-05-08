using Application.Daos;
using Application.Resources;

namespace AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            this.CreateMap<PersonalDetailsDao, PersonalDetailsResource>();
        }
    }
}