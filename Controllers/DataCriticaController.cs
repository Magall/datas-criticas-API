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
    public class DataCriticaController : ControllerBase
    {
        private readonly IDataCriticaService _service;
        public DataCriticaController(IDataCriticaService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CreateDataCritica([FromBody] DataCriticaInsertDto dcDto)
        {
            var res = _service.CreateDataCritica(dcDto);
            return res;
        }
       [HttpGet]
        public IActionResult GetDatasCritica()
        {
            var res = _service.GetDatasCriticas();
            return Ok(res);   
        }
        [HttpGet("[action]")]
        public IActionResult GetMonthAhead()
        {
            var res = _service.GetMonthAhead();
            return Ok(res);
        }
    }
}