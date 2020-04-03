using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Models
{
    public class DataCritica
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string nome { get; set; }
        [ForeignKey("nome")]
        public Departamento departamento { get; set; }
    }
}
