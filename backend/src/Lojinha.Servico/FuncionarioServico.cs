using AutoMapper;
using Lojinha.Dominio.Models;
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
    public class FuncionarioServico : IFuncionarioServico
    {
        private readonly IMapper _mapper;
        public readonly IFuncionarioRepositorio _funcionarioRepo;
        public FuncionarioServico(IFuncionarioRepositorio funcionarioRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _funcionarioRepo = funcionarioRepositorio;
        }
        public async Task<FuncionarioDto> GetFuncionarioPorMatricula(int matricula)
        {
            try
            {
                var func = await _funcionarioRepo.GetFuncionarioPorMatriculaAsync(matricula);
                var funcMapped = _mapper.Map<FuncionarioDto>(func);

                return func != null ? funcMapped : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<FuncionarioDto[]> GetFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioRepo.GetTodosFuncionariosAsync();
                var funcMapped = _mapper.Map<FuncionarioDto[]>(funcionarios);

                return funcionarios != null ? funcMapped : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
