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
                            using (StreamReader reader = new StreamReader(nombreArchivoMaterias)) //creo un objeto que tiene el metodo de abrir el archivo y leer.
                                                                                                  // uso using para que se cierre el .txt cuando lo termino de usar
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
                               
                                
                            }

                            foreach (CursoMateria item in CursoMateria.TotalCursos)
                            {
                                Console.WriteLine(item.NumerodeCurso + " " + item.NumeroDeMateria  );
                            }

                            break;
                        } 

                    case 2:
                        //alumnoIngresado.mostrarMateriasDisponibles();
                        alumnoIngresado.inscribir();
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
