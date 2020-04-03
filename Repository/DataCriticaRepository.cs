using DatasCriticasApi.Data;
using DatasCriticasApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Repository.IRepository
{
    public class DataCriticaRepository:IDataCriticaRepository
    {
        private readonly ApplicationDbContext _db;

        public DataCriticaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Save()
        {
            try
            {
            return _db.SaveChanges() >= 0 ? true : false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool CreateDataCritica([FromBody]DataCritica dc)
        {
            _db.DatasCriticas.Add(dc);
            return Save();
        }

        public ICollection<DataCritica> GetDatasCriticas()
        {
            return _db.DatasCriticas.OrderBy(dc => dc.InitialDate).ToList();
        }

        public DataCritica GetDataCritica(int id)
        {
            return _db.DatasCriticas.FirstOrDefault(dc => dc.Id == id);
        }

        public ICollection<DataCritica> GetPeriodDatasCriticas(DateTime InitialDate, DateTime EndDate)
        {
            return _db.DatasCriticas.Where(obj => obj.InitialDate >= InitialDate && obj.EndDate < EndDate).ToList();
        }

        public bool DeleteDataCritica(DataCritica dc)
        {
            _db.DatasCriticas.Remove(dc);
            return Save();
        }

        public bool UpdateDataCritica(DataCritica dc)
        {
            _db.DatasCriticas.Update(dc);
            return Save();
        }

        public bool DataCriticaExists(int id)
        {
           return  _db.DatasCriticas.Any(d => d.Id ==id);
        }

    }
}
