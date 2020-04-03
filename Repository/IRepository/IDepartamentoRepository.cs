using DatasCriticasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Repository.IRepository
{
    public interface IDepartamentoRepository
    {
        ICollection<Departamento> GetDepartametos();
        Departamento GetDepartamento(string nome);
        bool DepartamentoExists(string nome);
        bool CreateDepartamento(Departamento departamento);
        bool UpdateDepartamento(Departamento departamento);
        bool DeleteDepartamento(Departamento departamento);
        bool Save();
    }
}
