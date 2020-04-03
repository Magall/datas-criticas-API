using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Models
{
    public class Departamento
    {
        [Key]
        public string Nome { get; set; }
    }
}
