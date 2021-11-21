using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITipoIdentificacionService
    {
        Task<IEnumerable<TipoIdentificacionEntity>> GetLista();
    }
    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly IDataAccess sql;
        public TipoIdentificacionService(IDataAccess _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<TipoIdentificacionEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<TipoIdentificacionEntity>("TipoIdentificacionLista");
                return await result;
            }
            catch (Exception EX)
            {
                throw;
            }
        }
    }
}
