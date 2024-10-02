using AutoMapper;
using Bibliosharp_API.Data;
using Bibliosharp_API.Data.Dto.ClienteDto;
using Bibliosharp_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Bibliosharp_API.Services; 
public class ClienteService {

    private IMapper _mapper;
    private ApplicationDbContext _context;
   
    public ClienteService(IMapper mapper, ApplicationDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Cliente> AddClienteAsync(CreateClienteDto dto) {

        Cliente cliente = _mapper.Map<Cliente>(dto);

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    } 

    public async Task<ReadClienteDto> findClienteById(int id) {
        var cliente = await _context.Clientes.FindAsync(id);
        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
        return clienteDto;
    }

    public async Task<IEnumerable<ReadClienteDto>> getClientesAsync() {
        var clienteList =  _mapper.Map<List<ReadClienteDto>>(await _context.Clientes.ToListAsync());
        return clienteList;
    }

    public async Task<Cliente> UpdateClieteAsync(UpdateClienteDto dto) {
        Cliente cliente = _mapper.Map<Cliente>(dto);
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> deleteClienteAsync(int id) {
        var cliente = await _context.Clientes.FindAsync(id);
       
        if (cliente == null) return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }


    
}
