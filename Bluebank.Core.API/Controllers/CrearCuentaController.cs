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
    [RoutePrefix("BlueBank/CrearCuenta")]
    public class CrearCuentaController : ApiController
    {

        #region Atributos
        CrearCuentasFunciones funciones;

        #endregion

        #region Constructores
        public CrearCuentaController()
        {
            funciones = funciones ?? new CrearCuentasFunciones();
        }
        #endregion

        #region Controlador
        [HttpPost]
        [Route("CrearCuenta")]
        public IHttpActionResult RealizarCrearCuenta([FromBody] PersonaDTO cuenta)
        {
            try
            {
                return Ok(funciones.CrearCuenta(cuenta));
            }
            catch (Exception wiliamcito)
            {
                return InternalServerError(wiliamcito);
            }
        }
        #endregion





    }
}