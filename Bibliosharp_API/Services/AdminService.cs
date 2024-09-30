using AutoMapper;
using Bibliosharp_API.Data.Dto;
using Bibliosharp_API.Models;
using Microsoft.AspNetCore.Identity;

namespace Bibliosharp_API.Services; 
public class AdminService {

    private IMapper _mapper;
    private UserManager<Admin> _userManager;
    private SignInManager<Admin> _signInManager;


    public AdminService(IMapper mapper, UserManager<Admin> userManager, SignInManager<Admin> signInManager) {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
       
    }

    public async Task addAdmin(CreateAdminDto dto) {
        Admin admin = _mapper.Map<Admin>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(admin, dto.Password);

        if (!resultado.Succeeded) {
            throw new ApplicationException("Falha ao cadastrar administrador");
        }
    }

}
