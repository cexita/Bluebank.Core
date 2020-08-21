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

    [RoutePrefix("BlueBank/Consignar")]
    public class ConsignarController : ApiController
    {
        #region Atributos
        ConsignarFunciones funciones;

        #endregion

        #region Constructores
        public ConsignarController()
        {
            funciones = funciones ?? new ConsignarFunciones();
        }
        #endregion

        #region Controlador
        [HttpPost]
        [Route("ConsignarPorCuentaNumero")]
        public IHttpActionResult EjecutarConsignacionCuenta([FromBody] CuentaDTO cuenta)
        {
            try
            {
                return Ok(funciones.ConsignarPorCuentaNumero(cuenta));
            }
            catch (Exception wiliamcito)
            {
                return InternalServerError(wiliamcito);
            }
        }
        #endregion
    }
}
