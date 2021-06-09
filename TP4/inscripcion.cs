using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP4
{
    static class Inscripcion
    {
        const string nombreArchivoMaterias = @"C:\Users\pc\source\repos\CAI\TP4\TP4\Materias.txt";
        public static List<Curso> ofertaCuatrimestral;
        public static List<List<int>> registroDeSolicitudesEnviadas;
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
                
                if (!DatosAlumnos.validarAlumno(registro))//Si el registro del alumno no existe, le saldrá un error
                {
                    Console.WriteLine("Registro no encontrado. Toque cualquier tecla para continuar");                    
                    int answer = Helper.ValidarNumero(); 
                }
                else
                {                    
                    cicloRegistro = true;                    
                }
                Console.Clear();
            } while (!cicloRegistro);
            return registro;
        } 
       
        public static void confirmarSolicitud(Alumno alumno)
        {            
            registroDeSolicitudesEnviadas.Add(alumno.listaCursosSolicitados);
        }
        public static void levantarArchivoMaterias()
        {
            ofertaCuatrimestral = new List<Curso>();
            registroDeSolicitudesEnviadas = new List<List<int>>();
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
                        Curso cuenta = new Curso(linea);
                        ofertaCuatrimestral.Add(cuenta);
                    }
                    contador++;
                }
            }
        }
    }
}
