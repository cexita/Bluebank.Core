using Bluebank.Core.BL.Funciones;
using Bluebank.Core.Data.Entidades;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bluebank.Core.API.Controllers
{
    [RoutePrefix("BlueBank/Retirar")]
    public class RetirarController : ApiController
    {
        #region Atributos
        RetirarFunciones funciones;

        #endregion

        #region Constructores
        public RetirarController()
        {
            funciones = funciones ?? new RetirarFunciones();
        }
        #endregion

        #region Controlador
        [HttpPost]
        [Route("RetirarPorCuentaNumero")]

        public IHttpActionResult EjecutarRetiroCuenta([FromBody] CuentaDTO cuenta)
        {
            try
            {
                return Ok(funciones.RetirarPorCuentaNumero(cuenta));
            }
            catch (Exception wiliamcito)
            {
                return InternalServerError(wiliamcito);
            }
        }
        #endregion
    }
}
