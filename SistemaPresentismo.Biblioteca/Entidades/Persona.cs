using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca
{
    public abstract class Persona
    {
        // ATRIBUTOS
        protected string _nombre;
        protected string _apellido;

        // PROPIEDADES
        public string Nombre => _nombre;
        public string Apellido => _apellido;

        // MÉTODOS
        public Persona(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        public override string ToString()
        {
            return this.Display();
        }

        internal abstract string Display();
    }
}
