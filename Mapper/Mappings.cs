using AutoMapper;
using DatasCriticasApi.Models;
using DatasCriticasApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<DataCritica, DataCriticaInsertDto>().ReverseMap();
            CreateMap<DataCritica, DataCriticaGetDto>().ReverseMap();
        }
    }
}
