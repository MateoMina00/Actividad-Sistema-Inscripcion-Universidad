using System;
using System.IO;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Inscripcion.levantarArchivoMaterias();
            int registro = Inscripcion.ingreso();
            Alumno alumnoIngresado = new Alumno(registro);                                   
            bool menuPrincipal = false;
            do
            {
                Console.Clear();
                int numeroMenuPrincipal = Inscripcion.mostrarMenu();
                bool salir = false;
                switch (numeroMenuPrincipal)
                {
                    case 1:
                        {
                            Curso.mostrarOferta();                            
                            salir = true;
                            break;
                        }

                    case 2:
                        //if (!alumnoIngresado.validacionAlumnoRegular())
                        //{
                        //    Console.WriteLine("Usted es un alumno calificado como Libre. Dirijase por favor a Departamento de Alumnos");
                        //}
                        //else
                        //{
                            alumnoIngresado.inscribir(); //valida 4 materias
                            alumnoIngresado.mostrarMateriasDisponibles(); //muestra lo que podes rendir
                            alumnoIngresado.enviarSolicitud(); //Tengo que validar, que ingrese lo que muestre la lista a rendir.
                            Inscripcion.confirmarSolicitud(alumnoIngresado);
                            alumnoIngresado.mostrarInscripcion();
                        salir = true;
                            
                        //}
                        break;

                    case 9:
                        Console.WriteLine("Nota: se ha generado un archivo inscripciones.txt en la ruta local el cual contiene info de todas las incripciones.");
                        salir = true;
                        menuPrincipal = true;
                        break;
                } while (!salir) ;
            } while (!menuPrincipal);
        }
    }
}