using AutoMapper;
using DatasCriticasApi.Models.Dtos;
using DatasCriticasApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Services.IServices
{
    public interface IDataCriticaService
    {
        public ObjectResult CreateDataCritica(DataCriticaInsertDto dcDto);
        public List<DataCriticaGetDto> GetDatasCriticas();
        public List<DataCriticaGetDto> GetMonthAhead();
    }
}
