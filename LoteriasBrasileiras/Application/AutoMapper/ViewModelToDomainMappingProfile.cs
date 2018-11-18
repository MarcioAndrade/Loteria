using AutoMapper;
using Domain.MegaSena;
using Domain.LotoFacil;
using Application.ViewModel;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LotoFacilViewModel, LotoFacilCEF>();
            CreateMap<MegaSenaViewModel, MegaSenaCEF>();
        }
    }
}
