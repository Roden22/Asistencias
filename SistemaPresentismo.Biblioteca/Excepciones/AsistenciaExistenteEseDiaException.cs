using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca.Excepciones
{
    public class AsistenciaExistenteEseDiaException : Exception
    {
        public AsistenciaExistenteEseDiaException(string message) : base(message) { }
    }
}
