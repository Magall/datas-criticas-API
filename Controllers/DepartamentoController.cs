using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatasCriticasApi.Models;
using DatasCriticasApi.Models.Dtos;
using DatasCriticasApi.Repository.IRepository;
using DatasCriticasApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatasCriticasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _service;
        public DepartamentoController( IDepartamentoService service)
        {
            _service = service;
        }     
        [HttpGet]
        public IActionResult getDepartamentos()
        {
            var res = _service.GetDapartamentos();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult CreateDepartamento([FromBody] DepartamentoDto depDto)     
        {
            var res = _service.CreateDepartamento(depDto);
            Console.WriteLine(res.StatusCode);
            return res;            
        }
        [HttpDelete("{nome}")]
        public IActionResult deleteDepartamento(string nome)
        {
            var res = _service.DeleteDepartamento(nome);
            return res;
        } 
    }
}