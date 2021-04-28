using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPresentismo.Biblioteca;
using ConsolaGenerico;
using SistemaPresentismo.Biblioteca.Excepciones;

namespace Parcial1.DENTE.SistemaPresentismo.Interfaz
{
    public class Program
    {
        private static Presentismo _presentismo;

        static Program()
        {
            _presentismo = new Presentismo();
        }
        // modificar lo que corresponda para que solo finalice el
        // programa si el usuario presiona X en el menú
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
            if(preceptorActivo == null)
            {
                Consola.ImprimirError("No hay ningún preceptor activo. Presione una tecla para salir.");
                Console.ReadKey();
                return;
            }

            string opcionMenu = "";
            bool salir = false;
            do
            {
                DesplegarOpcionesMenu();
                try
                {
                    opcionMenu = Consola.LeerString("opción", false).ToUpper(); // pedir el valor
                }
                catch (Exception e)
                {
                    Consola.ImprimirError(e.Message);
                }

                switch (opcionMenu)
                {
                    case "1":
                        TomarAsistencia(preceptorActivo);
                        break;
                    case "2":
                        MostrarAsistencia();
                        break;
                    case "X":
                        salir = true;
                        break;
                    default:
                        Consola.ImprimirError("Opción inválida. Intente nuevamente.");
                        break;
                }
            } while (salir == false);
            
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("---------- MENU ----------");
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
            Console.WriteLine("--------------------------\n");           
        }
        static void TomarAsistencia(Preceptor p)
        {
            List<Alumno> alumnos = new List<Alumno>();
            List<Asistencia> asistencias = new List<Asistencia>();
            string respuestaPresente = "";
            bool esRespuestaValida = false;
            const string presente = "S";
            const string ausente = "N";
            try
            {

                // Ingreso fecha
                string fecha = Consola.LeerString("fecha de asistencia a registrar", false);

                // Listar los alumnos
                alumnos = _presentismo.GetListaAlumnos();
                foreach (Alumno alumno in alumnos)
                {
                    // para cada alumno solo preguntar si está presente
                    if (alumno is AlumnoRegular)
                    {
                        do
                        {
                            respuestaPresente = "";
                            try
                            {
                                respuestaPresente = Consola.LeerString($"si está presente { alumno.ToString()} (S/N) ").ToUpper();
                            }
                            catch (ParametroInvalidoException e)
                            {
                                // si tira excepción, va a ser respuesta inválida así que no hago nada.
                            }
                            esRespuestaValida = (respuestaPresente == presente || respuestaPresente == ausente);
                            if (!esRespuestaValida)
                            {
                                Consola.ImprimirError("Respuesta inválida, intente nuevamente.");
                            }
                        } while (!esRespuestaValida);

                        // agrego la lista de asistencia
                        asistencias.Add(new Asistencia(fecha, p, alumno, (respuestaPresente == presente ? true : false)));

                    }
                    else
                    {
                        Console.WriteLine($"El alumno {alumno.ToString()} es oyente.");
                    }

                }

                _presentismo.AgregarAsistencia(asistencias);
                Console.WriteLine("\nCarga de asistencias finalizada.\n");
            }
            catch (ParametroInvalidoException e)
            {
                Consola.ImprimirError(e.Message);
            }
            catch(SinAlumnosRegistradosException e)
            {
                Consola.ImprimirError(e.Message);
            }
            catch(Exception e)
            {
                Consola.ImprimirError(e.Message);
            }
           
        }
        static void MostrarAsistencia()
        {
            // Ingreso fecha
            string fecha = Consola.LeerString("fecha de asistencia a mostrar", false);

            List<Asistencia> asistencias = _presentismo.GetAsistenciasPorFecha(fecha);

            Console.WriteLine(""); // dejo un espacio
            if(asistencias == null || asistencias.Count < 1)
            {
                Console.WriteLine($"No hay asistencias cargadas para la fecha {fecha}.");
            }
            else
            {
                // muestro el toString de cada asistencia
                foreach (Asistencia asistencia in asistencias)
                {
                    Console.WriteLine(asistencia.ToString());
                }
            }
            
        }
    }

}
