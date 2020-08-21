using Bluebank.Core.BL.Comunes;
using Bluebank.Core.Data.Data;
using Bluebank.Core.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.BL.Funciones
{
    public class ConsignarFunciones : IDisposable
    {
        #region Atributos
        BlueBankEntities Context;
        Logger log;


        #endregion

        #region Constructor
        public ConsignarFunciones()
        {
            log = log ?? new Logger();
        }

        #endregion

        #region Metodos Publicos
        public TransaccionesDTO ConsignarPorCuentaNumero(CuentaDTO cuenta)
        {
            try
            {
                TransaccionesDTO resultado_transaccion = new TransaccionesDTO();

                using (Context = new BlueBankEntities())
                {
                    var resultado = Context.Tbl_Cuentas.SingleOrDefault(c => c.CuentaNumero.ToString() == cuenta.CuentaNumero.ToString());

                    if (resultado != null)
                    {
                        resultado.Saldo += double.Parse(cuenta.Saldo);
                    }

                    Context.SaveChanges();

                    Tbl_TiposTranssacciones tipo_transaccion = Context.Tbl_TiposTranssacciones.SingleOrDefault(d => d.Id == 1);

                    Tbl_Transsacciones transacciones = new Tbl_Transsacciones { CuentaNumero = int.Parse(cuenta.CuentaNumero), Saldo = double.Parse(cuenta.Saldo), Tbl_TiposTranssacciones = tipo_transaccion };

                    transacciones = Context.Tbl_Transsacciones.Add(transacciones);
                    Context.SaveChanges();

                    if (transacciones != null)
                    {
                        resultado_transaccion = new TransaccionesDTO
                        {
                            CuentaNumero = transacciones.CuentaNumero,
                            TipoTranssaccion = transacciones.Tbl_TiposTranssacciones.Id,
                            TranssaccionNumero = transacciones.Numero,
                            TranssaccionSaldo = transacciones.Saldo
                        };
                    }

                }
                return resultado_transaccion;
            }
            catch (Exception ex)
            {
                log.ErrorRegister(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region Métodos
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
