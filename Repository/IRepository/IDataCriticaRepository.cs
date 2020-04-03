using DatasCriticasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCriticasApi.Repository.IRepository
{
    public interface IDataCriticaRepository
    {
        ICollection<DataCritica> GetDatasCriticas();
        DataCritica GetDataCritica(int id);
        ICollection<DataCritica> GetPeriodDatasCriticas(DateTime InitialDate ,DateTime EndDate);
        bool CreateDataCritica(DataCritica dc);
        bool DeleteDataCritica (DataCritica dc);
        bool UpdateDataCritica(DataCritica dc);
        bool DataCriticaExists(int id);
        bool Save();
    }
}
