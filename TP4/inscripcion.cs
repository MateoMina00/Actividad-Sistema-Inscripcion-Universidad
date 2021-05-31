using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP4
{
    static class inscripcion
    {
        const string nombreArchivoMaterias = @"C:\Users\mateo\source\repos\CAI\TP4\TP4\Materiass.txt";
        public static List<CursoMateria> TotalCursos;
        public static List<List<int>> totalSolicitudes;
        public static int ingreso()
        {
            int registro;
            bool cicloRegistro = false;
           
            do
            {
                Console.Clear();
                Console.WriteLine("Sistema de inscripción");
                Console.WriteLine("Favor de ingresar su registro");
                registro = Helper.ValidarNumero();
                
                if (!DatosAlumnos.validarAlumno(registro))//Si el registro del alumno no existe, preguntar que desea
                {
                    Console.WriteLine("Registro no encontrado");
                    
                    int answer = Helper.ValidarNumero(); 
                    

                }
                else
                {
                    Console.WriteLine("Registro ingresado correctamnete");
                    cicloRegistro = true;
                    Console.ReadKey();
                }
            } while (!cicloRegistro);
            return registro;
        } 
        public static int mostrarMenu() //Ojo que si ingresar un numero incorrecto, rompe.
        {
            Console.WriteLine("1. Ver oferta academica. \n2. Inscribite \n9. Salir");
            int opcion = Helper.validarNroMenu();
            return opcion;
        }
        public static void confirmarSolicitud(Alumno alumno)
        {
            
            totalSolicitudes.Add(alumno.listaCursosSolicitados);
        }
        public static void levantarArchivoMaterias()
        {
            TotalCursos = new List<CursoMateria>();
            totalSolicitudes = new List<List<int>>();
            using (StreamReader reader = new StreamReader(nombreArchivoMaterias)) //creo un objeto que tiene el metodo de abrir el archivo y leer.                                                                                  // uso using para que se cierre el .txt cuando lo termino de usar
            {
                int contador = 1;
                while (!reader.EndOfStream) // !End of stream me permite recorrer todas las líneas del txt
                {
                    //      0               1             2             3        4          5        6
                    //Nro de Curso;Nro de Materia;Nombre de Materia;Docente;Dia y Horario;Sede; Correlativas(separadas por '-') 
                    string linea = reader.ReadLine();
                    if (contador > 1) // el contador lo uso para que no me genere un objeto con el título
                    {
                        CursoMateria cuenta = new CursoMateria(linea);
                        TotalCursos.Add(cuenta);
                    }
                    contador++;
                }

            }
        }
    }
}
