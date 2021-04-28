using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca
{
    public class AlumnoRegular : Alumno
    {
        // ATRIBUTOS
        private string _email;

        // PROPIEDADES
        public string Email => _email;

        // MÉTODOS
        public AlumnoRegular(int registro, string nombre, string apellido, string email) : base(registro, nombre, apellido)
        {
            _email = email;
        }


    }
}
