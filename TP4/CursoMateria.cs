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

        int nroDeCurso;
        int nroDeMateria;
        string nombreDeCurso;
        string docente;
        string horarioDeClase;
        string sede;
        string correlativas;

        public int NumerodeCurso
        {
            get { return this.nroDeCurso; }
        }

        public int NumeroDeMateria
        {
            get { return this.nroDeMateria; }
        }

        public string NombreDeCurso
        {
            get { return docente; }
        }
        public string HorarioDeClase
        {
            get { return horarioDeClase; }
        }
        // gon
        public string Sede
        {
            get { return sede; }
        }

        public string Correlativas
        {
            get { return correlativas; }
        }

        public CursoMateria ( string linea)
        {
            TotalCursos = new List<CursoMateria>();
            var arraydeLinea = linea.Split(';');
            
            nroDeCurso = int.Parse(arraydeLinea[0]);
            nroDeMateria= int.Parse(arraydeLinea[1]);
            nombreDeCurso= arraydeLinea[2];
            docente= arraydeLinea[3];
            horarioDeClase= arraydeLinea[4];
            sede= arraydeLinea[5];
            correlativas= arraydeLinea[6];

        }
            
            
      

    }
}
