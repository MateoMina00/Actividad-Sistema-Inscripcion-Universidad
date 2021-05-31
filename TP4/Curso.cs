using System;
using System.Collections.Generic;
using System.Text;


namespace TP4
{
    class Curso
    {
        //      0               1             2             3        4          5        6
        //Nro de Curso;Nro de Materia;Nombre de Materia;Docente;Dia y Horario;Sede; Correlativas(separadas por '-')         
        
        

        //Variables

        int nroDeCurso;
        int numerodeMateria;
        string nombreDeMateria;               
        string docente;
        string horarioDeClase;
        string sede;
        List<int> listaDeCorrelativas;

        //Propiedades
        public int NumerodeCurso
        {
            get { return this.nroDeCurso; }
            set { nroDeCurso = value; }
        }

        public int NumeroDeMateria
        {
            get { return numerodeMateria; }
            set { numerodeMateria = value; }
        }
        public string NombreDeMateria
        {
            get { return this.nombreDeMateria; }
            set { nombreDeMateria = value; }
        }

        public string Docente
        {
            get { return docente; }
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
        
        public Curso(string linea)
        {


            listaDeCorrelativas = new List<int>();
            var arraydeLinea = linea.Split(';');
            nroDeCurso = int.Parse(arraydeLinea[0]);
            NumeroDeMateria = int.Parse(arraydeLinea[1]);
            NombreDeMateria = arraydeLinea[2];
            docente = arraydeLinea[3];
            horarioDeClase = arraydeLinea[4];
            sede = arraydeLinea[5];
            var lineaCorrelativas = arraydeLinea[6]; //linea correlativa
            var arrayCorrelativas = lineaCorrelativas.Split('-'); //array asd-asd-asd
            for (int i = 0; i < arrayCorrelativas.Length; i++) //recorro el array, por cada dato dentro de larray,
            {
                if (!int.TryParse(arrayCorrelativas[i], out int prueba))  //agarro y lo parseo a un int. Ese int, lo agrego a
                {                                                           //la lista de correlativas por cada materia.  
                    listaDeCorrelativas.Add(prueba);
                }
            }
        }
        public static void mostrarOferta()
        {
            Console.Clear();
            Console.WriteLine("Oferta del cuatrimestre; ");
            foreach (Curso item in Inscripcion.OfertaCuatrimestral)
            {
                Console.WriteLine(item.NumerodeCurso + " " + item.NumeroDeMateria + " " + item.Docente + " " + item.HorarioDeClase
                    + " " + item.Sede);
            }

            Console.WriteLine("Toque para salir");
            Console.ReadKey();

        }
        
        public static void creacionDeListaGeneral()
        {
            Inscripcion.OfertaCuatrimestral = new List<Curso>();
        }
        




    }
}
