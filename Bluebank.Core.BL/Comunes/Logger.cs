using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.BL.Comunes
{
    public class Logger
    {
        #region Atributos
        private readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Permite Escribir un mensaje de Error en el Log de Errores configurado - Log4Net
        /// </summary>
        /// <param name="Error">Mensaje de Error a publicar</param>
        public void WriteError(string Error)
        {
            log4net.Config.XmlConfigurator.Configure();
            Log.Error(Error);
        }

        /// <summary>
        /// Escribe en el log configurado, un mensaje y su respectiva excepción - Log4Net
        /// </summary>
        /// <param name="message">Mensaje a Escribir</param>
        /// <param name="ex">Excepción a Escribir</param>
        public void WriteLogErrorException(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        /// <summary>
        /// Escribe en el log configurado, la excepción de manera detallada cuando falle el aplicativo - Log4Net
        /// </summary>
        /// <param name="ex"></param>
        public void ErrorRegister(Exception ex)
        {
            log4net.Config.XmlConfigurator.Configure();
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("Tipo de Excepción: " + ex.GetType().ToString());
            msg.Append("StackTrace:");
            msg.AppendLine(ex.StackTrace);
            msg.AppendLine("Objeto : " + ex.TargetSite.Module.Name);
            msg.AppendLine("Metodo : " + ex.TargetSite.Name);
            msg.AppendLine("Mensaje: ");
            msg.AppendLine(ex.Message);


            if (ex.InnerException != null)
            {
                msg.AppendLine("Detalle " + ex.InnerException.Message.ToString());
                msg.AppendLine("StackTrace Detalle: " + ex.InnerException.StackTrace);
            }

            Log.Error(msg.ToString());
        }

        #endregion
    }
}
