using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace TP4
{
    class Alumno
    {
        //Variables
        int registro;
        string nombre;
        string apellido;
        string materiasAprobadas; //string---> lista de materias en linea.
        string condicion;
        bool ultimasCuatroMaterias;//Si es true, no necesita validar correlativas.
        List<int> listaMateriasAprobadas;
        List<int> listaMateriasParaRendir = new List<int>();
        List<int> listaMateriasParaRendirConCorrelativa = new List<int>();
        public List<int> listaCursosSolicitados = new List<int>();

        //Propiedades

        public int Registro
        {
            set { registro = value; }
            get { return registro; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public string Apellido
        {
            set { apellido = value; }
            get { return apellido; }
        }

        public string Condicion
        {
            set { condicion = value; }
            get { return condicion; }
        }

        public bool UltimasCuatroMaterias
        {
            set { ultimasCuatroMaterias = value; }
            get { return ultimasCuatroMaterias; }
        }

        //Constructores      

        public Alumno(int registro)
        {
            string ruta = DatosAlumnos.traerRuta();           
            if (File.Exists(ruta))
            {
                StreamReader reader = new StreamReader(ruta);
                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine(); //A partir de cada linea, tengo que construir un diccionario, que me permita validar que existe.                    
                    var arraylinea = linea.Split(';');
                    if (int.Parse(arraylinea[0]) == registro)
                    {
                        Registro = int.Parse(arraylinea[0]);
                        Apellido = arraylinea[2];
                        Nombre = arraylinea[1];
                        materiasAprobadas = arraylinea[3]; //Separamos las materias por guion     
                        listaMateriasAprobadas=new List<int>();
                        Condicion = arraylinea[4];
                        var arrayLista = materiasAprobadas.Split(','); //Agarro el string, lo separo por guion, y me queda una lista de las materias aprobadas.
                        foreach (var materiasSegunRegistro in arrayLista) //por cada materia, la agrego a la lista de materias aprobadas, ya parseadas.
                        {
                            int parseado;
                            if (!int.TryParse(materiasSegunRegistro, out parseado))
                            {
                                continue;
                            }
                            else
                            {
                                listaMateriasAprobadas.Add(parseado);
                            }

                        }
                    }
                    else continue;
                }
                
            }
            else Console.WriteLine("Error en la base de datos. Revise la conexion");
        }
        public void mostrarMateriasDisponibles()
        {

            if (!ultimasCuatroMaterias) //Si no esta en las ultimas 4, tomo las correlativas.
            {
                foreach (int codigoMateriaAprobada in listaMateriasAprobadas)
                {
                    foreach (var CodigoMateriaOfrecida in Inscripcion.ofertaCuatrimestral)
                    {
                        if (codigoMateriaAprobada != CodigoMateriaOfrecida.NumeroDeMateria)
                            if (!listaMateriasParaRendir.Contains(CodigoMateriaOfrecida.NumeroDeMateria))
                                listaMateriasParaRendir.Add(CodigoMateriaOfrecida.NumeroDeMateria);
                    }
                }

                
                for (int i = 0; i < listaMateriasAprobadas.Count; i++)
                {
                  foreach(Curso item in Inscripcion.ofertaCuatrimestral)
                    {
                        if (item.Correlativas.Contains(listaMateriasAprobadas[i])) //Si lista de correlativas del item contiene listaMateriasAprobadas[i]
                        {
                            listaMateriasParaRendir.Remove(listaMateriasAprobadas[i]);
                        }

                    }


                }

                int contador = 0;
                Console.Clear();
                //A partir de aca, tengo la lista de las materias que puedo rendir, pero me falta las correlativas.
                foreach (int codigoDeMateria in listaMateriasAprobadas)
                {
                    
                    for (int i = 0; i < Inscripcion.ofertaCuatrimestral.Count; i++)
                    {
                        if (Inscripcion.ofertaCuatrimestral[i].Correlativas.Count == 0) //si no tiene correlativas, lo agrego a la lista
                        {
                            if (!listaMateriasParaRendirConCorrelativa.Contains(Inscripcion.ofertaCuatrimestral[i].NumeroDeMateria))
                                listaMateriasParaRendirConCorrelativa.Add(Inscripcion.ofertaCuatrimestral[i].NumeroDeMateria);
                        }
                        if (Inscripcion.ofertaCuatrimestral[i].Correlativas.Contains(codigoDeMateria)) //si tiene correlativa aprobada entro al if
                        {
                            contador = 0;
                            int cantidadCorrelativas = Inscripcion.ofertaCuatrimestral[i].Correlativas.Count;
                            foreach (int codigoDeCorrelativa in Inscripcion.ofertaCuatrimestral[i].Correlativas) //recorro la correlativa de cada materia
                            {                                
                                foreach (int codigoAprobada in listaMateriasAprobadas) //recorro todas las materias aprobadas, si coincide
                                                                                        //con correlativa, sumo contador
                                {
                                    if (codigoAprobada == codigoDeCorrelativa)
                                        contador += 1;
                                }
                            }
                            if (contador == cantidadCorrelativas) //Si el contador es igual a la cantidad de correlativa, lo agrego
                                if (!listaMateriasParaRendirConCorrelativa.Contains(Inscripcion.ofertaCuatrimestral[i].NumeroDeMateria))
                                    listaMateriasParaRendirConCorrelativa.Add(Inscripcion.ofertaCuatrimestral[i].NumeroDeMateria);

                        }
                        
                    }
                }
                if (listaMateriasParaRendirConCorrelativa.Count == 0) //Si la lista queda vacia, no tiene materias para rendir
                    Console.WriteLine("El alumno no tiene materias disponibles para rendir");
                else //Si no esta vacia, muestro las materias que puede cursar
                {
                    foreach (var item in listaMateriasParaRendirConCorrelativa)
                    {
                        foreach (var curso in Inscripcion.ofertaCuatrimestral)
                        {
                            if (item == curso.NumeroDeMateria)
                            {
                                Console.WriteLine($"\nCurso: {curso.NumerodeCurso} - Nro. Materia:{curso.NumeroDeMateria}- {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                            }
                        }
                    }
                }

            }
            else
            {
                foreach (int codigoMateriaAprobada in listaMateriasAprobadas) //Muestro las materias que puede cursar (sin correlativas)
                {
                    foreach (var CodigoMateriaOfrecida in Inscripcion.ofertaCuatrimestral)
                    {
                        if (codigoMateriaAprobada != CodigoMateriaOfrecida.NumeroDeMateria)
                            if (!listaMateriasParaRendir.Contains(CodigoMateriaOfrecida.NumeroDeMateria))
                                listaMateriasParaRendir.Add(CodigoMateriaOfrecida.NumeroDeMateria);
                    }
                }
                int contador = 0;
                Console.Clear();
                foreach (var item in listaMateriasParaRendir)
                {
                    foreach (var curso in Inscripcion.ofertaCuatrimestral)
                    {
                        if (item == curso.NumeroDeMateria)
                        {
                            contador += 1;
                            Console.WriteLine($"\nCurso: {curso.NumerodeCurso} - Nro. Materia:{curso.NumeroDeMateria}- {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                        }
                    }
                }
                if (contador == 0)
                    Console.WriteLine("El alumno no tiene cursos disponibles para inscribirse.");
                

            }

        }
        public void inscribir()
        {
            Console.Clear();
            Console.WriteLine("¿Estás cursando las últimas 4 materias?.\n 1.Si \n 2.No");
            int respuesta = Helper.ValidarNumero();
            if (respuesta == 1)
            {
                ultimasCuatroMaterias = true;
            }
            else
            {
                ultimasCuatroMaterias = false;
            }
        }

        public bool validacionAlumnoRegular()
        {
            bool validacion = true;


            if (this.Condicion == "Libre")
            {
                validacion = false;
            }


            return validacion;
        }
        public void enviarSolicitud()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("El alumno puede inscribirse en los siguientes cursos.");
            Console.WriteLine("Tener en cuenta: \nNo debe anotarse en 2 cursos diferentes de la misma materia.\n Puede inscribirse en un máximo de 3 cursos.");
            int contador = 0;
            bool ciclo = false;
            do
            {
                Console.WriteLine("Ingrese código del curso: ");
                int CodigoIngresadoCurso = Helper.ValidarNumero();
                bool existe = false;
                for (int r = 0; r < listaMateriasParaRendir.Count; r++)
                {
                    for (int o = 0; o < Inscripcion.ofertaCuatrimestral.Count; o++)
                    {
                        if (Inscripcion.ofertaCuatrimestral[o].NumeroDeMateria == listaMateriasParaRendir[r]) //Si la materia que me trae, coincide 
                        {
                            
                            foreach (var curso in Inscripcion.ofertaCuatrimestral)
                            {
                                bool existeEnLista = listaCursosSolicitados.Contains(CodigoIngresadoCurso);
                                if (curso.NumerodeCurso == CodigoIngresadoCurso && !existeEnLista )//Si el curso de la materia que trajo, es igual al codigo ingresado
                                {
                                    existe = true;
                                    contador += 1;
                                    int saliente = CodigoIngresadoCurso;
                                    listaCursosSolicitados.Add(saliente);
                                    if (contador == 3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Se ha generado la inscripción. Toque para continuar");
                                        Console.ReadKey();
                                        ciclo = true;
                                    }
                                    else
                                    {                                        
                                        Console.WriteLine("Ingrese: \n1.Para inscribirse a otro curso. \n9. Para finalizar la inscripción.");
                                        int respuesta = Helper.ValidarNumero();
                                        if (respuesta == 9)
                                            ciclo = true;

                                    }
                                }
                                continue;

                            }
                        }
                        
                    }
                }
                if (!existe)
                {
                    Console.WriteLine("El codigo ingresado es incorrecto o el alumno ya se ha inscripto a dicho curso.");
                    Console.WriteLine("1. Intentar de nuevo. 9 para salir.");
                    int respuesta = Helper.ValidarNumero();
                    if (respuesta == 9)
                        ciclo = true;
                }
            } while (!ciclo);            
            Console.Clear();
            Console.WriteLine("Se ha enviado la solicitud de inscripción a cursos. En 14 dias se publicará los resultados.");
            

        }
        public void mostrarInscripcion()
        {
            Console.WriteLine("El alumno se ha inscripto en: ");
            foreach (var codigoCurso in listaCursosSolicitados)
            {
                foreach (var curso in Inscripcion.ofertaCuatrimestral)
                {
                    if(codigoCurso == curso.NumerodeCurso)
                    {
                        Console.WriteLine($"Curso: {curso.NumerodeCurso} - Nro. Materia:{curso.NumeroDeMateria}- {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
    
