using AutoMapper;
using Bibliosharp_API.Data.Dto.ClienteDto;
using Bibliosharp_API.Data.Dto.LivroDto;
using Bibliosharp_API.Models;

namespace Bibliosharp_API.Profiles; 
public class LivroProfile: Profile {

    public LivroProfile() {

        CreateMap<CreateLivroDto, Livro>();
        CreateMap<UpdateLivroDto, Livro>();
        CreateMap<Livro, ReadLivroDto>();
    }
}
