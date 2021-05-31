using System;
using System.IO;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            inscripcion.levantarArchivoMaterias();
            int registro = inscripcion.ingreso();
            Alumno alumnoIngresado = new Alumno(registro);                       
            
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
                            CursoMateria.mostrarOferta();
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