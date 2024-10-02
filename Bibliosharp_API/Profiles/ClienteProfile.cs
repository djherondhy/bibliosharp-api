using AutoMapper;
using Bibliosharp_API.Data.Dto.ClienteDto;
using Bibliosharp_API.Data.Dto.LivroDto;
using Bibliosharp_API.Models;

namespace Bibliosharp_API.Profiles; 
public class ClienteProfile: Profile {

    public ClienteProfile() {

        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>()
          .ForMember(dest => dest.LivrosEmprestados, opt => opt.MapFrom(cliente => cliente.LivrosEmprestados.Select(emprestimo => new ReadLivroEmprestadoDto {
              Id = emprestimo.Livro.Id,
              Titulo = emprestimo.Livro.Titulo,
              Autor = emprestimo.Livro.Autor,
              DataDevolucao = (DateTime)emprestimo.DataDevolucao,
              DataEmprestimo = (DateTime)emprestimo.DataEmprestimo,

          }).ToList()));
    }
}
