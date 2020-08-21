using Bluebank.Core.BL.Funciones;
using Bluebank.Core.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bluebank.Core.API.Controllers
{
    [RoutePrefix("Bluebank/Cuentas")]
    public class CuentasController : ApiController
    {
        #region Atributos
        CuentasFunciones funciones;

        #endregion

        #region Constructores
        public CuentasController() 
        {
            funciones = funciones ?? new CuentasFunciones();
        }

        #endregion

        #region Controladores
        [HttpPost]
        [Route("ObtenerSaldoCuenta")]
        public IHttpActionResult ObtenerSaldoCuenta([FromBody] CuentaDTO numero_cuenta) 
        {
            try
            {
                return Ok(funciones.ObtenerCuentaPorNumero(numero_cuenta));
            }
            catch (Exception wiliamcito)
            {
                return InternalServerError(wiliamcito);
            }
        }

        #endregion
    }
}
