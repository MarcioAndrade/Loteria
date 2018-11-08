using AutoMapper;
using Domain.LotoFacil;
using Application.ViewModel;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LotoFacilViewModel, LotoFacilCEF>();
        }
    }
}
