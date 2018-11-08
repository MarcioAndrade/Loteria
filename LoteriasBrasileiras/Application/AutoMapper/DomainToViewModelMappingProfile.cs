using AutoMapper;
using Domain.LotoFacil;
using Application.ViewModel;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<LotoFacilCEF, LotoFacilViewModel>();
        }
    }
}
