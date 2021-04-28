using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca
{
    public class Asistencia
    {
        // ATRIBUTOS
        private string _fechaAsistencia;
        private DateTime _fechaHoraReal;
        private Preceptor _preceptor;
        private Alumno _alumno;
        private bool _estaPresente;

        // PROPIEDADES
        public string FechaAsistencia => _fechaAsistencia;

        // MÉTODOS
        public Asistencia(string fecha, Preceptor preceptor, Alumno alumno, bool estaPresente)
        {
            _fechaAsistencia = fecha;
            _fechaHoraReal = DateTime.Now;
            _preceptor = preceptor;
            _alumno = alumno;
            _estaPresente = estaPresente;
        }
        public override string ToString()
        {
            return $"{_fechaAsistencia} {_alumno.ToString()} está presente {(_estaPresente?"SI":"NO")} por {_preceptor.ToString()} registrado el {_fechaHoraReal.ToString("yyy-MM-dd")}";
        }
    }
}
