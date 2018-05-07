using AutoMapper;

namespace Diller.Models.ViewModels
{
    public class ViewModelToEntityMappingManager: Profile
    {
        public ViewModelToEntityMappingManager()
        {
            CreateMap<Manager, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}