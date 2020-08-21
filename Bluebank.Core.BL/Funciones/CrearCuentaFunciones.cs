using Bluebank.Core.BL.Comunes;
using Bluebank.Core.Data.Data;
using Bluebank.Core.Data.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.BL.Funciones
{
    public class CrearCuentasFunciones : IDisposable
    {
        #region Atributos
        BlueBankEntities Context;
        Logger log;


        #endregion

        
        #region Constructor
        public CrearCuentasFunciones()
        {
            log = log ?? new Logger();
        }

        #endregion

        #region Metodos Publicos
        public TransaccionesDTO CrearCuenta(PersonaDTO PersonaNueva)
        {
            try
            {
                TransaccionesDTO nuevacuenta = new TransaccionesDTO();
                if (PersonaNueva != null)
                {
                    Tbl_Personas persona = new Tbl_Personas();
                    using (Context = new BlueBankEntities())
                    {
                        var validar = Context.Tbl_Personas.SingleOrDefault(c => c.cedula.ToString() == PersonaNueva.cedula.ToString());
                        
                        if (validar == null)
                        {
                            persona = new Tbl_Personas { Nombre = PersonaNueva.Nombre, cedula = PersonaNueva.cedula };
                            persona = Context.Tbl_Personas.Add(persona);
                            Context.SaveChanges();

                            var query = (from tabla in Context.Tbl_Personas
                                         where tabla.cedula == PersonaNueva.cedula
                                         select new { Id = tabla.Id }
                                    ).FirstOrDefault();

                            Tbl_Cuentas cuenta = new Tbl_Cuentas { Persona = query.Id, Saldo = PersonaNueva.saldo };

                            cuenta = Context.Tbl_Cuentas.Add(cuenta);
                            Context.SaveChanges();

                            var validarcuenta = (from tabla in Context.Tbl_Cuentas
                                         where tabla.Persona == query.Id
                                         select tabla.CuentaNumero).FirstOrDefault();

                            Tbl_TiposTranssacciones tipo_transaccion = Context.Tbl_TiposTranssacciones.SingleOrDefault(d => d.Id == 4);

                            Tbl_Transsacciones transacciones = new Tbl_Transsacciones { CuentaNumero = int.Parse(validarcuenta.ToString()), Saldo = double.Parse(cuenta.Saldo.ToString()), Tbl_TiposTranssacciones = tipo_transaccion };

                            transacciones = Context.Tbl_Transsacciones.Add(transacciones);
                            Context.SaveChanges();

                            if (transacciones != null)
                            {
                                nuevacuenta = new TransaccionesDTO
                                {
                                    CuentaNumero = transacciones.CuentaNumero,
                                    TipoTranssaccion = transacciones.Tbl_TiposTranssacciones.Id,
                                    TranssaccionNumero = transacciones.Numero,
                                    TranssaccionSaldo = transacciones.Saldo
                                };
                            }

                        }

                    } 
                }
                return nuevacuenta;             
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
