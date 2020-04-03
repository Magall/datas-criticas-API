using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Models.Dtos
{
    public class DataCriticaGetDto
    { 
        public int Id { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string nome { get; set; }   
    }
}
