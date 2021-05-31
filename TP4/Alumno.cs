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
                        materiasAprobadas = arraylinea[4]; //Separamos las materias por guion     
                        listaMateriasAprobadas=new List<int>();
                        Condicion = arraylinea[3];
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
                    foreach (var CodigoMateriaOfrecida in inscripcion.TotalCursos)
                    {
                        if (codigoMateriaAprobada != CodigoMateriaOfrecida.NumerodeCurso)
                            if (!listaMateriasParaRendir.Contains(CodigoMateriaOfrecida.NumerodeCurso))
                                listaMateriasParaRendir.Add(CodigoMateriaOfrecida.NumerodeCurso);
                    }
                }

                for (int i = 0; i < listaMateriasAprobadas.Count; i++)
                {
                    foreach (CursoMateria curso in inscripcion.TotalCursos) //Cada curso en la lista de todas las materias
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
                foreach (var item in listaMateriasParaRendir)
                {
                    foreach (var curso in inscripcion.TotalCursos)
                    {
                        if(item == curso.NumerodeCurso)
                        {
                            contador += 1;
                            Console.WriteLine($"Curso: {curso.NumerodeCurso} - {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                        }
                    }
                }
                if (contador == 0)
                    Console.WriteLine("No tienes cursos disponibles para rendir");
                else
                {
                    Console.WriteLine("Podes rendir los Siguientes cursos: ");
                }
            }
            else
            {
                foreach (int codigoMateriaAprobada in listaMateriasAprobadas)
                {
                    foreach (var CodigoMateriaOfrecida in inscripcion.TotalCursos)
                    {
                        if (codigoMateriaAprobada != CodigoMateriaOfrecida.NumerodeCurso)
                            if (!listaMateriasParaRendir.Contains(CodigoMateriaOfrecida.NumerodeCurso))
                                listaMateriasParaRendir.Add(CodigoMateriaOfrecida.NumerodeCurso);
                    }
                }
                int contador = 0;
                foreach (var item in listaMateriasParaRendir)
                {
                    foreach (var curso in inscripcion.TotalCursos)
                    {
                        if (item == curso.NumerodeCurso)
                        {
                            contador += 1;
                            Console.WriteLine($"Curso: {curso.NumerodeCurso} - {curso.NombreDeMateria} - {curso.Docente} - {curso.HorarioDeClase} - {curso.Sede}");
                        }
                    }
                }
                if (contador == 0)
                    Console.WriteLine("No tienes cursos disponibles para rendir");
                else
                {
                    Console.WriteLine("Podes rendir los Siguientes cursos: ");
                }

            }

        }
        public void inscribir()
        {
            Console.WriteLine("¿Estas cursando las últimas 4 materias?. 1. Si 2.No)");
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
            int contador = 0;
            bool ciclo = false;
            do
            {
                Console.WriteLine("Favor de ingresar el codigo del curso: ");
                int CodigoIngresadoCurso = Helper.ValidarNumero();

                if (listaMateriasParaRendir.Contains(CodigoIngresadoCurso))
                {
                    listaCursosSolicitados.Add(CodigoIngresadoCurso);
                    contador += 1;
                    if (contador == 3)
                    {
                        Console.WriteLine("Inscripcion completa");
                        ciclo = true;
                    }
                    else
                    {
                        Console.WriteLine("Presione 1 para agregar otro curso. 9 para salir.");
                        int respuesta = Helper.ValidarNumero();
                        if (respuesta == 9)
                            ciclo = true;
                    }

                }
                else Console.WriteLine("Favor de ingresar un codigo correcto");

            } while (!ciclo);
        }
    }
}
    
