using DatasCriticasApi.Data;
using DatasCriticasApi.Models;
using DatasCriticasApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartamentoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateDepartamento(Departamento departamento)
        {
            _db.Departamentos.Add(departamento);
            return Save();
        }

        public bool DeleteDepartamento(Departamento departamento)
        {
            _db.Departamentos.Remove(departamento);
            return Save();
        }

        public bool DepartamentoExists(string nome)
        {
            bool res = _db.Departamentos.Any(dep => dep.Nome == nome);
            return res;
        }

        public Departamento GetDepartamento(string nome)
        {
            return _db.Departamentos.FirstOrDefault(dep => dep.Nome ==nome);
        }

        public ICollection<Departamento> GetDepartametos()
        {
            var departamentos = _db.Departamentos.OrderBy(dep => dep.Nome).ToList();
            return departamentos;
        }
        public bool UpdateDepartamento(Departamento departamento)
        {
            _db.Departamentos.Update(departamento);
            return Save();
        }
        public bool Save()
        {
            try
            { 
             return _db.SaveChanges() >= 0 ? true : false;
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return false;
            }
        }

       
    }
}
