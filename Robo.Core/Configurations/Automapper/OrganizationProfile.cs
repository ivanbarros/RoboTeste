using AutoMapper;
using Robo.Domain.Entities;
using Robo.Infra.Queries.Braco;

namespace Robo.Core.Configurations.Automapper
{
    public class OrganizationProfile : Profile
    {
        /*BracoDireitoStatusResponse*/
        public OrganizationProfile()
        {
            CreateMap<BracoStatusResponse,Braco>().ReverseMap();
        }
    }
}
