using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca
{
    public abstract class Alumno : Persona
    {
        // ATRIBUTOS
        private int _registro;

        // PROPIEDADES
        public int Registro { get => _registro; set => _registro = value; }

        // MÉTODOS
        public Alumno(int registro, string nombre, string apellido) : base(nombre, apellido)
        {
            _registro = registro;
        }

        internal override string Display()
        {
            return $"{_nombre.ToUpper()} ({_registro})";
        }
    }
}
