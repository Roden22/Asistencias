using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca.Excepciones
{
    class AsistenciaInconsistenteException : Exception
    {
        public AsistenciaInconsistenteException(string message) : base(message) { }
    }
}
