using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bluebank.Core;
using Bluebank.Core.BL.Funciones;
using Bluebank.Core.Data.Entidades;
using Bluebank.Core.Data.Data;
using System.Runtime.Remoting.Contexts;
using System.Data;


namespace Bluebank.Core.Test
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
                #region Arrange
                var funcionalidad = new CrearCuentasFunciones();
                var personatest = new PersonaDTO() { cedula = 20123456, Nombre = "javi", saldo = 1000};
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
