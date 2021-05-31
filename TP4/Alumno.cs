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
        string materiasAprobadas;
        string condicion;
        bool ultimasCuatroMaterias;//Si es true, no necesita validar correlativas.
        List<int> listaMateriasAprobadas;
        List<int> listaMateriasParaRendir = new List<int>();
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
            string ruta = DatosAlumnos.dameRuta();           
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
                    foreach (var CodigoMateriaOfrecida in Inscripcion.OfertaCuatrimestral)
                    {
                        if (codigoMateriaAprobada != CodigoMateriaOfrecida.NumeroDeMateria)
                            if (!listaMateriasParaRendir.Contains(CodigoMateriaOfrecida.NumeroDeMateria))
                                listaMateriasParaRendir.Add(CodigoMateriaOfrecida.NumeroDeMateria);
                    }
                }

                for (int i = 0; i < listaMateriasAprobadas.Count; i++)
                {
                    foreach (Curso curso in Inscripcion.OfertaCuatrimestral) //Cada curso en la lista de todas las materias
                    {
                        for (int a = 0; a < curso.Correlativas.Count; a++)  //Para cada correlativa de esa materia
                        {
                            int contadorCorrelativa = 0;
                            if (curso.Correlativas[a] == listaMateriasAprobadas[i]) //Si esa correlativa esta en la lista, lo meto.
                            {
                                contadorCorrelativa += 1;
                            }
                            if (contadorCorrelativa != curso.Correlativas.Count)
                                listaMateriasParaRendir.Remove(listaMateriasAprobadas[i]);
                        }
                    }
                }               
                int contador = 0;
                Console.Clear();
                foreach (var item in listaMateriasParaRendir)
                {
                    foreach (var curso in Inscripcion.OfertaCuatrimestral)
                    {
                        
                        if(item == curso.NumeroDeMateria)
                        {
                            contador += 1;
                            Console.WriteLine($"\nCurso: {curso.NumerodeCurso} - Nro. Materia:{curso.NumeroDeMateria}- {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                        }
                    }
                }
                if (contador == 0)
                    Console.WriteLine("No tienes cursos disponibles para rendir");
                
            }
            else
            {
                foreach (int codigoMateriaAprobada in listaMateriasAprobadas)
                {
                    foreach (var CodigoMateriaOfrecida in Inscripcion.OfertaCuatrimestral)
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
                    foreach (var curso in Inscripcion.OfertaCuatrimestral)
                    {
                        if (item == curso.NumeroDeMateria)
                        {
                            contador += 1;
                            Console.WriteLine($"\nCurso: {curso.NumerodeCurso} - Nro. Materia:{curso.NumeroDeMateria}- {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                        }
                    }
                }
                if (contador == 0)
                    Console.WriteLine("No tienes cursos disponibles para rendir");
                

            }

        }
        public void inscribir()
        {
            Console.Clear();
            Console.WriteLine("¿Estas cursando las últimas 4 materias?.\n 1.Si \n 2.No");
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
            Console.WriteLine("Podes inscribirte en los siguientes cursos. Ingresa su codigo (Podes un maximo de 3 por inscripción)");
            Console.WriteLine("Tene cuidado de anotarte 2 veces en la misma materia (revisa su codigo).En todo caso contactate con el administrador");
            int contador = 0;
            bool ciclo = false;
            do
            {
                Console.WriteLine("Ingrese codigo: ");
                int CodigoIngresadoCurso = Helper.ValidarNumero();
                bool existe = false;
                for (int r = 0; r < listaMateriasParaRendir.Count; r++)
                {
                    for (int o = 0; o < Inscripcion.OfertaCuatrimestral.Count; o++)
                    {
                        if (Inscripcion.OfertaCuatrimestral[o].NumeroDeMateria == listaMateriasParaRendir[r]) //Si la materia que me trae, coincide 
                        {
                            
                            foreach (var curso in Inscripcion.OfertaCuatrimestral)
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
                                        Console.WriteLine("Inscripcion completa. Toque para continuar");
                                        Console.ReadKey();
                                        ciclo = true;
                                    }
                                    else
                                    {                                        
                                        Console.WriteLine("Ingrese: \n1.Para agregar otro curso. \n9. Finalizar");
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
                    Console.WriteLine("El codigo ingresado es incorrecto o ya ha sido inscripto.");
                    Console.WriteLine("1. Intentar de nuevo. 9 para salir.");
                    int respuesta = Helper.ValidarNumero();
                    if (respuesta == 9)
                        ciclo = true;
                }
            } while (!ciclo);            
            Console.Clear();
            Console.WriteLine("Se ha generado certificado. En 14 dias se publicará los resultados.");
            

        }
        public void mostrarInscripcion()
        {
            Console.WriteLine("Usted se ha inscripto en: ");
            foreach (var codigoCurso in listaCursosSolicitados)
            {
                foreach (var curso in Inscripcion.OfertaCuatrimestral)
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
    
