using AutoMapper;
using Domain.MegaSena;
using Domain.LotoFacil;
using Application.ViewModel;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<LotoFacilCEF, LotoFacilViewModel>();
            CreateMap<MegaSenaCEF, MegaSenaViewModel>();
        }
    }
}
