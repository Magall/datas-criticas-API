using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Models.Dtos
{
    public class DataCriticaInsertDto
    {
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string nome { get; set; }
    }
}
