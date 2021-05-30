using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP4
{
    class CursoMateria
    {
        //      0               1             2             3        4          5        6
        //Nro de Curso;Nro de Materia;Nombre de Materia;Docente;Dia y Horario;Sede; Correlativas(separadas por '-')         
        
        public static List<CursoMateria> TotalCursos;
        

        //Variables

        int nroDeCurso;
        int nroDeMateria;
        string nombreDeCurso;
        string docente;
        string horarioDeClase;
        string sede;
        List <int> listaDeCorrelativas;

        //Propiedades
        public int NumerodeCurso
        {
            get { return this.nroDeCurso; }
        }

        public int NumeroDeMateria
        {
            get { return this.nroDeMateria; }
        }

        public string Docente
        {
            get { return docente; }
        }

        public string NombreDeCurso
        {
            get { return nombreDeCurso; }
        }
        public string HorarioDeClase
        {
            get { return horarioDeClase; }
        }
        
        public string Sede
        {
            get { return sede; }
        }

        public List<int> Correlativas
        {
            get { return listaDeCorrelativas; }
        }

        public CursoMateria ( string linea)
        {
            TotalCursos = new List<CursoMateria>();
            listaDeCorrelativas = new List<int>();

            var arraydeLinea = linea.Split(';');
            
            nroDeCurso = int.Parse(arraydeLinea[0]);
            nroDeMateria= int.Parse(arraydeLinea[1]);
            nombreDeCurso = arraydeLinea[2];
            docente= arraydeLinea[3];
            horarioDeClase= arraydeLinea[4];
            sede= arraydeLinea[5];
           
            var lineaCorrelativas = arraydeLinea[6]; //linea correlativa
            var arrayCorrelativas = lineaCorrelativas.Split('-'); //array asd-asd-asd

            for ( int i = 0; i<arrayCorrelativas.Length; i++)
            {
                
                string numeroMateriaCorrelativa = arrayCorrelativas[i]; //recorro el array, por cada dato dentro de larray, agarro y lo parseo a un int. Ese int, lo agrego a
                int prueba = int.Parse(numeroMateriaCorrelativa);   //la lista de correlativas por cada materia.                                                             
               
                listaDeCorrelativas.Add(prueba);                             
            }


        }
            
            
      

    }
}
