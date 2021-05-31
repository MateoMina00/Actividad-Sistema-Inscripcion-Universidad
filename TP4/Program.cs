using System;
using System.IO;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            int registro = inscripcion.ingreso();
            Alumno alumnoIngresado = new Alumno(registro);
            string nombreArchivoMaterias = @"C:\Users\mateo\source\repos\CAI\TP4\TP4\Materiass.txt";
            CursoMateria.creacionDeListaGeneral();
            using (StreamReader reader = new StreamReader(nombreArchivoMaterias)) //creo un objeto que tiene el metodo de abrir el archivo y leer.                                                                                  // uso using para que se cierre el .txt cuando lo termino de usar
            {
                int contador = 1;
                while (!reader.EndOfStream) // !End of stream me permite recorrer todas las líneas del txt
                {
                    string linea = reader.ReadLine();
                    if (contador > 1) // el contador lo uso para que no me genere un objeto con el título
                    {
                        CursoMateria cuenta = new CursoMateria(linea);
                        CursoMateria.TotalCursos.Add(cuenta);
                    }
                    contador++;
                }
                //      0               1             2             3        4          5        6
                //Nro de Curso;Nro de Materia;Nombre de Materia;Docente;Dia y Horario;Sede; Correlativas(separadas por '-')    
            }
            Console.Clear();
            bool menuPrincipal = false;
            do
            {
                int numeroMenuPrincipal = inscripcion.mostrarMenu();
                bool salir = false;
                switch (numeroMenuPrincipal)
                {
                    case 1:
                        {
                            

                            foreach (CursoMateria item in CursoMateria.TotalCursos)
                            {
                                Console.WriteLine(item.NumerodeCurso + " " + item.NumeroDeMateria + " " + item.Docente + " " + item.HorarioDeClase
                                    + " " + item.Sede);
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        if (!alumnoIngresado.validacionAlumnoRegular())
                        {
                            Console.WriteLine("Usted es un alumno calificado como Libre. Dirijase por favor a Departamento de Alumnos");
                        }
                        else
                        {
                            alumnoIngresado.inscribir(); //valida 4 materias
                            alumnoIngresado.mostrarMateriasDisponibles(); //muestra lo que podes rendir
                            alumnoIngresado.enviarSolicitud(); //Tengo que validar, que ingrese lo que muestre la lista a rendir.
                            inscripcion.confirmarSolicitud(alumnoIngresado);
                            
                        }
                        break;

                    case 9:
                        salir = true;
                        menuPrincipal = true;
                        break;
                } while (!salir) ;
            } while (!menuPrincipal);
        }
    }
}