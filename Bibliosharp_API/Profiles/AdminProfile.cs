using AutoMapper;
using Bibliosharp_API.Data.Dto;
using Bibliosharp_API.Models;

namespace Bibliosharp_API.Profiles; 
public class AdminProfile: Profile {

    public AdminProfile() {

        CreateMap<CreateAdminDto, Admin>();
    }
}
