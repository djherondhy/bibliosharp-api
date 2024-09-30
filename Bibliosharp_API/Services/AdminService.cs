using AutoMapper;
using Bibliosharp_API.Data.Dto;
using Bibliosharp_API.Models;
using Microsoft.AspNetCore.Identity;

namespace Bibliosharp_API.Services; 
public class AdminService {

    private IMapper _mapper;
    private UserManager<Admin> _userManager;
    private SignInManager<Admin> _signInManager;
    private TokenService _tokenService;

    public AdminService(IMapper mapper, UserManager<Admin> userManager, SignInManager<Admin> signInManager, TokenService tokenService) {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task addAdmin(CreateAdminDto dto) {
        Admin admin = _mapper.Map<Admin>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(admin, dto.Password);

        if (!resultado.Succeeded) {
            throw new ApplicationException("Falha ao cadastrar administrador");
        }
    }

    public TokenService GetTokenService() {
        return _tokenService;
    }

    public async Task<string> Login(LoginAdminDto dto, TokenService _tokenService) {

        var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded) {
            throw new ApplicationException("Administrador Não Autenticado");
        }

        var admin = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(admin);

        return token;
    }

}
