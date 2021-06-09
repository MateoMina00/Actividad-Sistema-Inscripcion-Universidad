using System;
using System.IO;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Inscripcion.levantarArchivoMaterias();
            
            string archivoInscripcionesGeneradas = @"C:\Users\pc\source\repos\CAI\TP4\TP4\Inscripciones Solicitadas.txt";
            Alumno alumnoIngresado;
            bool MenuDeRegistro = false;

            do
            {
                int registro = Inscripcion.ingreso();
                alumnoIngresado = new Alumno(registro);
                Console.WriteLine("Buenos días Sr/a" + "  " + alumnoIngresado.Apellido);
                Console.WriteLine("Por favor, presione cualquier tecla para ingresar al menú principal.");
                Console.ReadKey();                
                bool menuPrincipal = false;

                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Ver oferta academica. \n2. Inscribite \n3. Solicitudes Enviadas \n8. Cambiar de Usuario " +
                        " \n9. Salir");
                    int numeroMenuPrincipal = Helper.ValidarNumero();
                                        

                    if (numeroMenuPrincipal > 0)
                    {
                        switch (numeroMenuPrincipal)
                        {
                            case 1:
                                {
                                    Curso.mostrarOferta();
                                    
                                    break;
                                }

                            case 2:
                                if (!alumnoIngresado.validacionAlumnoRegular())
                                {
                                    Console.WriteLine("Usted es un alumno calificado como Libre. Dirijase por favor a Departamento de Alumnos");
                                    Console.WriteLine("Presione cualquier tecla para volver a Menú Principal");

                                    
                                    Console.ReadKey();
                                }


                                else if (alumnoInscripto())
                                {
                                    Console.WriteLine("Usted ya se inscribió");
                                    Console.WriteLine("Presione cualquier tecla para volver a Menú Principal");
                                    Console.ReadKey();
                                    

                                }

                                else
                                {
                                    alumnoIngresado.inscribir(); //valida 4 materias
                                    alumnoIngresado.mostrarMateriasDisponibles(); //muestra lo que podes rendir
                                    alumnoIngresado.enviarSolicitud(); //Tengo que validar, que ingrese lo que muestre la lista a rendir.
                                    Inscripcion.confirmarSolicitud(alumnoIngresado);
                                    alumnoIngresado.mostrarInscripcion();
                                    Grabar();
                                    

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
                                    Console.WriteLine("El alumno no se ha inscripto todavía");
                                    
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Nombre;Apellido;Registro;Curso1;Curso2;Curso3");
                                    Console.WriteLine(reflejo);
                                    Console.ReadKey();
                                    
                                }

                                break;

                            case 8:
                                Console.WriteLine("Usted cambiará de usuario");
                                menuPrincipal = true;
                                break;
                            case 9:
                                Console.WriteLine("Nota: se ha generado un archivo Inscripciones Solicitadas.txt en la ruta local el cual contiene información de todas las incripciones.");
                                
                                MenuDeRegistro = true;
                                menuPrincipal = true;
                                Console.ReadKey();
                                break;

                            default:
                                {
                                    Console.WriteLine("Ingrese una opción valida");
                                    break;
                                }

                        } 
                    }
                } while (!menuPrincipal) ;
                
            } while (!MenuDeRegistro);

            void Grabar() // la solicitud de inscripción en un .txt
                                        // donde se encontrarán todas las solicitudes
                                        // que se vayan ingresando
            {
                string grabado="";                
                using (var writer = new StreamWriter(archivoInscripcionesGeneradas, append:true))
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

            bool alumnoInscripto()
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