using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules.AboutValidator;
using BusinessLayer.ValidationRules.AnnouncementValidator;
using BusinessLayer.ValidationRules.AppRoleValidator;
using BusinessLayer.ValidationRules.AppUserValidator;
using BusinessLayer.ValidationRules.ContactUsValidator;
using BusinessLayer.ValidationRules.DestinationValidator;
using BusinessLayer.ValidationRules.GuideValidator;
using BusinessLayer.ValidationRules.MailValidator;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppRoleDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.DestinationsDTOs;
using DTOLayer.DTOs.FeatureDTOs;
using DTOLayer.DTOs.GuideDTOs;
using DTOLayer.DTOs.MailDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDal>();

            services.AddScoped<IExelService, ExelManager>();
            services.AddScoped<IPdfService, PdfManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContectDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EFAccountDal>();

            services.AddScoped<INewslaterService, NewslaterManager>();
            services.AddScoped<INewsLaterDal, EFNewsLaterDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EFFeatureDal>();

            services.AddScoped<IFeature2Service, Feature2Manager>();
            services.AddScoped<IFeature2Dal, EFFeature2Dal>();

            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal, EFSubAboutDal>();

            services.AddScoped<ISocialContactService, SocialContactManager>();
            services.AddScoped<ISocialContactDal, EFSocialContactDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();

            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();
        }

        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementAddValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDTO>, AnnouncementUpdateValidator>();
            services.AddTransient<IValidator<AnnouncementListDTO>, AnnouncementListValidator>();
            services.AddTransient<IValidator<AppRoleAddDTO>, AppRoleAddValidator>();
            services.AddTransient<IValidator<AppUserRegisterDTO>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<AppUserResetPasswordDTO>, AppUserResetPasswordValidator>();
            services.AddTransient<IValidator<AppUserForGetPasswordDTO>, AppUserForGetPasswordValidator>();
            services.AddTransient<IValidator<AppUserSinginDTO>, AppUserSinginValidator>();
            services.AddTransient<IValidator<ReplyMessageDTO>, ReplyMessageValidator>();
            services.AddTransient<IValidator<SendMessageDTO>, SendContactUsValidator>();
            services.AddTransient<IValidator<DestinationAddDTO>, DestinationAddValidator>();
            services.AddTransient<IValidator<DestinationModelDTO>, DestinationModelValidator>();
            services.AddTransient<IValidator<MailRequestDTO>, MailRequestValidator>();
            services.AddTransient<IValidator<AboutViewDTO>, AboutViewValidator>();
            services.AddTransient<IValidator<RoleAssignViewDTO>, AppRoleAssignValidator>();
            services.AddTransient<IValidator<UpdateRoleViewDTO>, AppRoleUpdateValidator>();
            services.AddTransient<IValidator<CreateRoleViewDTO>, AppRoleCreateValidator>();
            services.AddTransient<IValidator<DestinationViewDTO>, DestinationViewValidator>();
            services.AddTransient<IValidator<GuideProfileEditViewDTO>, GuideProfileEditViewValidator>();
            services.AddTransient<IValidator<GuideViewDTO>, GuideValidator>();
            services.AddTransient<IValidator<FeatureViewDTO>, FeatureValidator>();
            services.AddTransient<IValidator<Feature2ViewDTO>, Feature2Validator>();
            services.AddTransient<IValidator<UserEditViewDTO>, UserEditViewValidator>();
            services.AddTransient<IValidator<AdminUserEditViewDTO>, AdminUserEditViewValidator>();
        }
    }
}