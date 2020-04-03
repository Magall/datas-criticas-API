using DatasCriticasApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Services.IServices
{
    public  interface IDepartamentoService
    {
        public List<DepartamentoDto> GetDapartamentos();
        public ObjectResult CreateDepartamento(DepartamentoDto depDto);
        public ObjectResult DeleteDepartamento(string nome);
    }
}
