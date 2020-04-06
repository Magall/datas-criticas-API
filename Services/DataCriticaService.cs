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

namespace DatasCriticasApi.Services
{
    public class DataCriticaService : IDataCriticaService
    {
        private IMapper _mapper;
        private IDataCriticaRepository _dcRepo;
        public DataCriticaService(IDataCriticaRepository dcRepo, IMapper mapper)
        {
            _dcRepo = dcRepo;
            _mapper = mapper;
        }
        public ObjectResult CreateDataCritica(DataCriticaInsertDto dcDto)
        {
                      
            var dc = _mapper.Map<DataCritica>(dcDto);
            DateTime today = DateTime.Today;
            // Validação para uma data nunca começar antes do dia de inserção e a data de fim sempre ser posterior a de início
            if (dc.InitialDate > dc.EndDate  || dc.InitialDate < today)
            {
                return new ObjectResult("Erro , verifique se as datas inseridas são posteriores ao dia de hoje e se a data final é posterior a inicial. ") { StatusCode = 500 };
            }
            else
            {

                if (_dcRepo.CreateDataCritica(dc))
                {
                   return new ObjectResult("Registro inserido") { StatusCode = 200 };
                }
                else
                {
                    return new ObjectResult("Erro ao inserir o Registro.") { StatusCode = 500 };
                    
                }
            }
            
        }

        public List<DataCriticaGetDto> GetDatasCriticas()
        {
            var dcs = _dcRepo.GetDatasCriticas();
            var dcDtos = new List<DataCriticaGetDto>();

            foreach (var dc in dcs)
            {
                dcDtos.Add(_mapper.Map<DataCriticaGetDto>(dc));
            }
            return dcDtos;
        }

        public List<DataCriticaGetDto> GetMonthAhead()
        {
            DateTime today = DateTime.Today;
            DateTime endDate = today.AddDays(30);
            var dcs = _dcRepo.GetPeriodDatasCriticas(today, endDate);
            var dcDtos = new List<DataCriticaGetDto>();
            foreach (var dc in dcs)
            {
                dcDtos.Add(_mapper.Map<DataCriticaGetDto>(dc));
            }
            return dcDtos;
        }
    }
}
