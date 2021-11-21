using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IContratoService
    {
        Task<DBEntity> Create(ContratoEntity entity);
        Task<DBEntity> Delete(ContratoEntity entity);
        Task<IEnumerable<ContratoEntity>> Get();
        Task<ContratoEntity> GetById(ContratoEntity entity);
        Task<DBEntity> Update(ContratoEntity entity);
    }

    public class ContratoService : IContratoService
    {
        private readonly IDataAccess sql;

        public ContratoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get


        public async Task<IEnumerable<ContratoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ContratoEntity, EmpleadoEntity>("acc.ContratoObtener", "IdContrato,IdEmpleado");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo GetById
        public async Task<ContratoEntity> GetById(ContratoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ContratoEntity>("acc.ContratoObtener", new
                { entity.IdContrato });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(ContratoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("acc.ContratoInsertar", new
                {
                    entity.IdEmpleado,
                    entity.TipoContrato,
                    entity.FechaInicio,
                    entity.FechaFin



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Update
        public async Task<DBEntity> Update(ContratoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("acc.ContratoActualizar", new
                {
                    entity.IdContrato,
                    entity.IdEmpleado,
                    entity.TipoContrato,
                    entity.FechaInicio,
                    entity.FechaFin



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> Delete(ContratoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("acc.ContratoEliminar", new
                {
                    entity.IdContrato,



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }






        #endregion
    }
}
