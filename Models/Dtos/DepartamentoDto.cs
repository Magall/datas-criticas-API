using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Models.Dtos
{
    public class DepartamentoDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
