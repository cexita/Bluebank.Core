using Bluebank.Core.BL.Funciones;
using Bluebank.Core.Data.Data;
using Bluebank.Core.Data.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.Test.BL.FuncionesTest
{
    [TestClass()]
    public class CuentasFuncionesTests : IDisposable
    {
        BlueBankEntities Context;
        [TestMethod()]
        public void ObtenerCuentaPorNumeroTest()
        {



            using (Context = new BlueBankEntities())
            {
                #region Arranges
                var funcionalidad = new CrearCuentasFunciones();
                var personatest = new PersonaDTO() { Nombre = "kata", cedula = 123, saldo = 12345 };
                #endregion



                #region Act
                var resultado = funcionalidad.CrearCuenta(personatest);
                #endregion


                #region Assert
                Assert.IsNotNull(resultado);
                #endregion
            }


        }
        #region Métodos
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
