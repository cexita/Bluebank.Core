using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.Data.Entidades
{
    public class TransaccionesDTO
    {
        public int TranssaccionNumero { get; set; }
        public int CuentaNumero { get; set; }
        public int TipoTranssaccion { get; set; }
        public double TranssaccionSaldo { get; set; }
    }
}
