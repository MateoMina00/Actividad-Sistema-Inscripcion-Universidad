using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        List<int> listaMateriasAprobadas = new List<int>();

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
            set { nombre = value; }
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
            Console.WriteLine("hola");
            foreach (CursoMateria item in CursoMateria.TotalCursos)
            {
                Console.WriteLine(item.NumerodeCurso + " " + item.NumeroDeMateria + " " + item.Docente + " " + item.HorarioDeClase
                    + " " + item.Sede);
            }
            ////int[] materiasDisponibles;
            //foreach (var curso in CursoMateria.TotalCursos)
            //{
            //    Console.WriteLine(curso.Correlativas);
            //    foreach (var numeroCorrelativa in curso.Correlativas)
            //    {
            //        Console.WriteLine(numeroCorrelativa);
            //    }
            //}
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
    }
}
    
