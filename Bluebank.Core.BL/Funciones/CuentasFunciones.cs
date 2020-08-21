using Bluebank.Core.BL.Comunes;
using Bluebank.Core.Data.Data;
using Bluebank.Core.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.BL.Funciones
{
    public class CuentasFunciones : IDisposable
    {
        #region Atributos
        BlueBankEntities Context;
        Logger Log;

        #endregion

        #region Constructor
        public CuentasFunciones()
        {
            Log = Log ?? new Logger();
            
        }

        #endregion

        #region Métodos Públicos
        public CuentaDTO ObtenerCuentaPorNumero(CuentaDTO numero_cuenta)
        {
            try
            {
                CuentaDTO cuenta = new CuentaDTO();
                using (Context = new BlueBankEntities()) 
                {
                    var query = (from tabla in Context.Tbl_Cuentas
                                where tabla.CuentaNumero.ToString() == numero_cuenta.CuentaNumero.ToString()
                                select new { CuentaNumero = tabla.CuentaNumero.ToString(), Saldo = tabla.Saldo.ToString(), PersonaId = tabla.Persona.ToString() }
                                ).FirstOrDefault();
                   
                        cuenta = new CuentaDTO
                        {
                            CuentaNumero = query.CuentaNumero,
                            Saldo = query.Saldo,
                            IdPersona = query.PersonaId
                        };
                 
                }
                return cuenta;
            }
            catch (Exception ex)
            {
                Log.ErrorRegister(ex);
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
