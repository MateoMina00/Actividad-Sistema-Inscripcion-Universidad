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
            string archivoInscripcionesGeneradas = @"C:\Users\pc\source\repos\CAI\TP4\TP4\Inscripciones Solicitadas.txt";
            

            
                Console.WriteLine("Buenos días Sr/a" + "  " + alumnoIngresado.Apellido);
                Console.WriteLine("Por Favor, presione cualquier tecla para ingresar al Menú");

                Console.ReadKey();

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
                            if (!alumnoIngresado.validacionAlumnoRegular())
                            {
                                Console.WriteLine("Usted es un alumno calificado como Libre. Dirijase por favor a Departamento de Alumnos");
                                Console.WriteLine("Presione cualquier tecla para volver a Menú Principal");

                                salir = true;
                                Console.ReadKey();
                            }


                            else if (SiYaEstaInscripto())
                            {
                                Console.WriteLine("Usted ya se inscribió");
                                Console.WriteLine("Presione cualquier tecla para volver a Menú Principal");
                                Console.ReadKey();
                                salir = true;

                            }

                            else
                            {
                                alumnoIngresado.inscribir(); //valida 4 materias
                                alumnoIngresado.mostrarMateriasDisponibles(); //muestra lo que podes rendir
                                alumnoIngresado.enviarSolicitud(); //Tengo que validar, que ingrese lo que muestre la lista a rendir.
                                Inscripcion.confirmarSolicitud(alumnoIngresado);
                                alumnoIngresado.mostrarInscripcion();
                                Grabar();
                                salir = true;

                            }
                            break;

                        case 3:
                            string reflejo = "";
                            bool validacion = false;
                            int contador = 1;

                            using (StreamReader reader = new StreamReader(archivoInscripcionesGeneradas))
                            {
                                while (!reader.EndOfStream)
                                {
                                    string linea = reader.ReadLine();

                                    if (contador > 1)
                                    {

                                        var separacion = linea.Split(';');
                                        string variable = separacion[2];
                                        int variableParseada = int.Parse(variable);

                                        if (variableParseada == alumnoIngresado.Registro)
                                        {
                                            validacion = true;
                                            reflejo = linea;
                                            break;
                                        }

                                    }
                                    contador++;
                                }


                            }

                            if (!validacion)
                            {
                                Console.WriteLine("Usted no se ha inscripto todavía");
                                salir = true;
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Nombre; Apellido; Registro; Curso1; Curso2; Curso3");
                                Console.WriteLine(reflejo);
                                Console.ReadKey();
                                salir = true;
                            }

                            break;
                       
                        case 9:
                            Console.WriteLine("Nota: se ha generado un archivo inscripciones.txt en la ruta local el cual contiene info de todas las incripciones.");
                            salir = true;
                            menuPrincipal = true;
                            break;
                    } while (!salir) ;
                } while (!menuPrincipal);
            

            void Grabar() // la solicitud de inscripción en un .txt
                                        // donde se encontrarán todas las solicitudes
                                        // que se vayan ingresando
            {
                string grabado="";
                string nombreArchivo = @"C:\Users\pc\source\repos\CAI\TP4\TP4\Inscripciones Solicitadas.txt";
                using (var writer = new StreamWriter(nombreArchivo,append:true))
                {
                    for (int i = 0; i < alumnoIngresado.listaCursosSolicitados.Count; i++)
                    {
                        
                        grabado += alumnoIngresado.listaCursosSolicitados[i].ToString();
                        grabado += ";";
                        
                    }

                    if( alumnoIngresado.listaCursosSolicitados.Count == 3)
                    writer.WriteLine( alumnoIngresado.Nombre +";" + alumnoIngresado.Apellido + ";" + alumnoIngresado.Registro +";"  + grabado);

                    if (alumnoIngresado.listaCursosSolicitados.Count == 2)
                        writer.WriteLine( alumnoIngresado.Nombre + ";" + alumnoIngresado.Apellido + ";" + alumnoIngresado.Registro + ";" + grabado +";");
                    
                    if (alumnoIngresado.listaCursosSolicitados.Count == 1)
                        writer.WriteLine( alumnoIngresado.Nombre + ";" + alumnoIngresado.Apellido + ";" + alumnoIngresado.Registro + ";" + grabado+";"+";");

                    



                }

            }

            bool SiYaEstaInscripto()
            {
                int contador = 1;
                bool yaInscripto = false;

                using (StreamReader reader = new StreamReader(archivoInscripcionesGeneradas))
                {
                    while (!reader.EndOfStream)
                    {
                        string linea = reader.ReadLine();

                        if (contador > 1)
                        {

                            var separacion = linea.Split(';');
                            string variable = separacion[2];
                            int variableParseada = int.Parse(variable);

                            if (variableParseada == alumnoIngresado.Registro)
                            {
                                yaInscripto = true;
                            }

                        }
                        contador++;
                    }
                }

                return yaInscripto;
            }

        }
    }
}