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
    public class ConsignarFuncionesTests : IDisposable
    {
        BlueBankEntities Context;
        [TestMethod()]
        public void ConsignarPorCuentaNumeroTest()
        {



            using (Context = new BlueBankEntities())
            {
                #region Arranges
                var funcionalidad = new ConsignarFunciones();
                var personatest = new CuentaDTO() { CuentaNumero = "1", Saldo = "100" };
                #endregion



                #region Act
                var resultado = funcionalidad.ConsignarPorCuentaNumero(personatest);
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