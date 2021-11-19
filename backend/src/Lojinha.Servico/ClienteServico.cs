using AutoMapper;
using Lojinha.Dominio.Models;
using Lojinha.Repositorio;
using Lojinha.Repositorio.Interfaces;
using Lojinha.Servico.DTOs;
using Lojinha.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico
{
    public class ClienteServico : IClienteServico
    {
        private readonly ICrudGenericoRepositorio _crudGenericoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServico(ICrudGenericoRepositorio  crudGenerioRepositorio, IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _crudGenericoRepositorio = crudGenerioRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<bool> AddCliente(ClienteDto cliente)
        {
            try           
            {
                var clienteMapped = _mapper.Map<Cliente>(cliente);

                _crudGenericoRepositorio.Add(clienteMapped);
                return await _crudGenericoRepositorio.SaveChangesAsync() ? true : throw new Exception("Houve algum erro ao cadastrar novo Cliente.");
    
            } 
            catch (Exception e) 
            { 
                throw new Exception(e.Message);  
            }
        }

        public async Task<ClienteDto[]> GetTodosClientes()
        {
            try
            {
                var clientes = await _clienteRepositorio.GetTodosClientesAsync();

                var clienteMapped = _mapper.Map<ClienteDto[]>(clientes);

                //return (clientes != null) ? clientes : null;
                return clienteMapped ?? null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ClienteDto> GetClientePorId(int id)
        {
            try
            {
                var cliente = await _clienteRepositorio.GetClientePorIdAsync(id);

                var clienteMapped = _mapper.Map<ClienteDto>(cliente);

                return clienteMapped ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ClienteDto> GetClientePorCpf(string cpf)
        {
            try
            {
                var cliente = await _clienteRepositorio.GetClientePorCpfAsync(cpf);

                var clienteMapped = _mapper.Map<ClienteDto>(cliente);

                return clienteMapped ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AtualizaCliente(string cpf, ClienteDto clienteNovo)
        {

            try
            {
                var cliente = await _clienteRepositorio.GetClientePorCpfAsync(cpf);
                if (cliente == null) return false;

                else
                {
                    var clienteId = cliente.ClienteId;
                    var clienteMapped = _mapper.Map(clienteNovo, cliente);

                    clienteMapped.ClienteId = clienteId; 
                    clienteMapped.Cpf = cpf;
                    //clienteMapped.Nome = clienteNovo.Nome;
                    //clienteMapped.Endereco = clienteNovo.Endereco;
                    //clienteMapped.Telefone = clienteNovo.Telefone;
                    
                    _crudGenericoRepositorio.Update(clienteMapped);
                    
                    if (await _crudGenericoRepositorio.SaveChangesAsync())
                    {
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> RemoveCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepositorio.GetClientePorIdAsync(id);


                if (cliente == null)
                {
                    throw new Exception("Erro ao excluir. Cliente não encontrado.");
                }

                var clienteMapped = _mapper.Map<Cliente>(cliente);
                _crudGenericoRepositorio.Remove(clienteMapped);

                return await _crudGenericoRepositorio.SaveChangesAsync();
            
            } catch(Exception e) 
            { 
                throw new Exception(e.Message); 
            }
        }

    }
}
