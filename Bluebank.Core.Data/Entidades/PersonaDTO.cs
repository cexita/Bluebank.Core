using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluebank.Core.Data.Entidades
{
    public class PersonaDTO
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public int cedula { get; set; }
        public double saldo { get; set; }


    }
}
