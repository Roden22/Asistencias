using SistemaPresentismo.Biblioteca.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPresentismo.Biblioteca
{
    public class Presentismo
    {
        // ATRIBUTOS
        private List<Preceptor> _preceptores;
        private List<Alumno> _alumnos;
        private List<Asistencia> _asistencias;

        // PROPIEDADES


        // MÉTODOS

        // iniciar Presentismo con los siguientes datos
        public Presentismo()
        {
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _preceptores = new List<Preceptor>();

            _preceptores.Add(new Preceptor(5, "Jorgelina", "Ramos", true));
            _preceptores.Add(new Preceptor(6, "Juan", "Gutierrez", false));

            _alumnos.Add(new AlumnoRegular(123, "Carlos", "Juárez", "cj@gmail.com"));
            _alumnos.Add(new AlumnoRegular(124, "Carla", "Jaime", "carla@gmail.com"));
            _alumnos.Add(new AlumnoOyente(320, "Ramona", "Vals"));
            _alumnos.Add(new AlumnoOyente(321, "Alejandro", "Medina"));
        }

        // Chequea si la asistencia existe.
        private bool AsistenciaRegistrada(string fecha)
        {
            return _asistencias.Find(a => a.FechaAsistencia == fecha) != null;
        }
        private int GetCantidadAlumnosRegulares()
        {
            return _alumnos.Where((a) => a is AlumnoRegular).ToList().Count;
        }
        public Preceptor GetPreceptorActivo()
        {
            return _preceptores.FirstOrDefault((p) => p.EsActivo == true);
        }

        public List<Alumno> GetListaAlumnos()
        {
            return _alumnos;
        }

        public void AgregarAsistencia(List<Asistencia> listaAsistencia)
        {
            if(listaAsistencia == null)
            {
                throw new ArgumentNullException("AgregarAsistencia(): Lista de asistencia inexistente.");
            }

            if (AsistenciaRegistrada(listaAsistencia.First().FechaAsistencia))
            {
                throw new AsistenciaExistenteEseDiaException("La asistencia ya fue registrada ese día.");
            }

            if(listaAsistencia.Count != GetCantidadAlumnosRegulares())
            {
                throw new AsistenciaInconsistenteException("La cantidad de alumnos cargados en la asistencia difiere de la cantidad de alumnos regulares registrados.");
            }

            if( _alumnos.Count == 0)
            {
                throw new SinAlumnosRegistradosException("No hay alumnos registrados para tomar asistencia");
            }

            _asistencias.AddRange(listaAsistencia);
        }

        public List<Asistencia> GetAsistenciasPorFecha(string fecha)
        {
            return _asistencias.Where((a) => a.FechaAsistencia == fecha).ToList();
        }
    }
}
