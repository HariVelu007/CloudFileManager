using AutoMapper;
using CFMDomainModel;
using CloudFileManager.Models.Account;

namespace CloudFileManager.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, RegisterView>().ReverseMap();
        }
    }
}
