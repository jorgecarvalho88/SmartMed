using AutoMapper;
using SmartMed.Dtos;

namespace SmartMed.Profiles
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<Model.Medication, MedicationDto>()
                .ForMember(
                dest => dest.UniqueId,
                from => from.MapFrom(x => x.UniqueId)
                )
                .ForMember(
                dest => dest.Name,
                from => from.MapFrom(x => x.Name)
                )
                .ForMember(
                dest => dest.Quantity,
                from => from.MapFrom(x => x.Quantity)
                )
                .ForMember(
                dest => dest.CreationDate,
                from => from.MapFrom(x => x.CreationDate)
                )
                .ForMember(
                dest => dest.Errors,
                from => from.MapFrom(x => x.Errors)
                );
        }
    }
}
