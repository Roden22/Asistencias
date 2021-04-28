using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca.Excepciones
{
    public class SinAlumnosRegistradosException : Exception
    {
        public SinAlumnosRegistradosException(string message) : base(message) { }
    }
}
