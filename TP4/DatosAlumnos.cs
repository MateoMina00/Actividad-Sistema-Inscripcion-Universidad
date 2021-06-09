using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP4
{
    static class DatosAlumnos
    {
        const string rutaAlumnos = @"C:\Users\pc\source\repos\CAI\TP4\TP4\AlumnosResguardo.csv"; //Archivo CSV de Alumnos.


        public static bool validarAlumno(int registro) //Si existe el registro,. me devuelve true, sino false.
        {
            if (!File.Exists(rutaAlumnos))
            {
                Console.WriteLine("No se ha encontrado la base de datos. Favor de revisar la ruta del archivo");
                return false;
            }
            else
            {
                StreamReader reader = new StreamReader(rutaAlumnos);
                bool banderaRegistro = false;
                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine(); //Agarro una linea
                    var arraylinea = linea.Split(';'); //Esa linea la vuelvo un array.
                    if(int.Parse(arraylinea[0]) != registro)
                    {
                        continue;
                    }
                    else
                    {                       
                        banderaRegistro = true;
                    }
                }
                if (!banderaRegistro)
                {                    
                    return banderaRegistro;
                }
                else
                {
                    return banderaRegistro;
                }
                
            }
        }


        public static string traerRuta()
            {
                return rutaAlumnos;
            }

        
    }
}
