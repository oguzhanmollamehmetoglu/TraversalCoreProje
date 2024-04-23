using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppRoleDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.DestinationsDTOs;
using DTOLayer.DTOs.FeatureDTOs;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AboutViewDTO, About>().ReverseMap();

            CreateMap<AnnouncementAddDTO, Announcement>();
            CreateMap<Announcement, AnnouncementAddDTO>();
            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();
            CreateMap<AnnouncementUpdateDTO, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDTO>();

            CreateMap<AppRoleAddDTO, AppRole>().ReverseMap();
            CreateMap<RoleAssignViewDTO, AppRole>().ReverseMap();
            CreateMap<UpdateRoleViewDTO, AppRole>().ReverseMap();
            CreateMap<CreateRoleViewDTO, AppRole>().ReverseMap();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();
            CreateMap<AppUserSinginDTO, AppUser>();
            CreateMap<AppUser, AppUserSinginDTO>();
            CreateMap<AppUserResetPasswordDTO, AppUser>();
            CreateMap<AppUser, AppUserResetPasswordDTO>();
            CreateMap<AppUserForGetPasswordDTO, AppUser>();
            CreateMap<AppUser, AppUserForGetPasswordDTO>();
            CreateMap<UserEditViewDTO, AppUser>().ReverseMap();
            CreateMap<AdminUserEditViewDTO, AppUser>().ReverseMap();

            CreateMap<CityAddDTO, Destination>();
            CreateMap<Destination, CityAddDTO>();
            CreateMap<DestinationAddDTO, Destination>();
            CreateMap<Destination, DestinationAddDTO>();
            CreateMap<DestinationModelDTO, Destination>();
            CreateMap<Destination, DestinationModelDTO>();
            CreateMap<DestinationViewDTO, Destination>().ReverseMap();

            CreateMap<SendMessageDTO, ContactUS>().ReverseMap();
            CreateMap<ReplyMessageDTO, ContactUS>().ReverseMap();

            CreateMap<GuideViewDTO, Guide>().ReverseMap();
            CreateMap<GuideProfileEditViewDTO, Guide>().ReverseMap();

            CreateMap<FeatureViewDTO, Feature>().ReverseMap();
            CreateMap<Feature2ViewDTO, Feature>().ReverseMap();
        }
    }
}