using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca
{
    public class Preceptor : Persona
    {
        // ATRIBUTOS
        private int _legajo;
        private bool _activo;

        // PROPIEDADES
        public int Legajo => _legajo;
        public bool EsActivo => _activo;

        // MÉTODOS
        public Preceptor(int legajo, string nombre, string apellido) : base(nombre, apellido)
        {
            _legajo = legajo;
            _activo = false;
        }
        public Preceptor(int legajo, string nombre, string apellido, bool activo) : base(nombre,apellido)
        {
            _legajo = legajo;
            _activo = activo;
        }

        internal override string Display()
        {
            return $"{_apellido.ToUpper()} - {_legajo}";
        }
    }
}
