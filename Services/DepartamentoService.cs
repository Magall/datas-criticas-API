using AutoMapper;
using DatasCriticasApi.Models;
using DatasCriticasApi.Models.Dtos;
using DatasCriticasApi.Repository.IRepository;
using DatasCriticasApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace DatasCriticasApi.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private IMapper _mapper;
        private IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IMapper mapper, IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
            _mapper = mapper;
        }
        public ObjectResult CreateDepartamento (DepartamentoDto depDto)
        {
            if (depDto == null)
            {
                return new ObjectResult("Registro não existe") { StatusCode = 400 };
            }
            else
            {
                var dept = _mapper.Map<Departamento>(depDto);
                if (_departamentoRepository.CreateDepartamento(dept))
                {
                    return new ObjectResult("Registro Criado com Suceeso") { StatusCode = 200 };
                }
                else
                {
                    return new ObjectResult("Erro ao criar o Registro") { StatusCode = 500 };
                }
            }
        }
        public ObjectResult DeleteDepartamento(string nome)
        {
            if (_departamentoRepository.DepartamentoExists(nome))
            {
                if (_departamentoRepository.DeleteDepartamento(_departamentoRepository.GetDepartamento(nome)))
                {
                    return new ObjectResult("Registro apagado com Suceeso") { StatusCode = 200 };
                }
                else
                {
                    return new ObjectResult("Erro ao apagar o Registro") { StatusCode = 500 };
                }
            }
            else
            {
                return new ObjectResult("Registro não existe") { StatusCode = 404 };
            }
        }

        public List<DepartamentoDto> GetDapartamentos()
        {
            var depts = _departamentoRepository.GetDepartametos();
            var deptsDto = new List<DepartamentoDto>();
            foreach (var dept in depts)
            {
                deptsDto.Add(_mapper.Map<DepartamentoDto>(dept));
            }
            return deptsDto;
        }

       
    }
}
