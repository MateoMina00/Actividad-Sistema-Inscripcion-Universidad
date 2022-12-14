using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


// Test
FE_OPERACION	DE_OPERACION	REFERENTE	DE_CANAL	CD_ZONA	CD_SUCURSAL	CD_RAMO	CD_PRODUCTO	DE_PRODUCTO	CD_PLAN	DE_PLAN	CD_USUARIO	NM_USUARIO	GRUPO	NU_POLIZA	NU_CERTIFICADO	FE_DESDE	FE_HASTA	TP_CUENTA	BINES	TIPO	NU_CUENTA	NU_NUP	TP_DOCUMENTO	NU_DOCUMENTO	NM_ASEGURADO	CD_SEGMENTO	DE_SEGMENTO	DE_SUBSEGMENTO	MT_CUOTA	PUNTOS	ST_CERTIFICADO	RESULTADO	COMENTARIO
06/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	36	LCWOM	LA CAJA CLIENTES WOMEN AUTOS	961	TERCEROS COMPLETO PACK COMODO	B055701	ALEMAN, ALEJANDRO	GRUPO ACOSTA SEGUROS	5150	17342501	06/09/2022	06/10/2022	V	421738	Debito	4217380005333430	30678050	D	30316573	LUNA, CLAUDIO FERNANDO	9	PYME	PYMES - COMERCIOS	4731	3809,39	7		
20/10/2022	REHABILITACION	SEBOK	CALL CENTER EXTERNO	901	901	30	ZUR01	ZURICH CLIENTES OPEN	23	TERCEROS COMPLETO	B051219	LEMME, ROSARIO	#N/D	94	776996	10/07/2019	10/07/2020	V	451766	Debito	4517660087938680	1544812	D	5077647	MASCARO,HECTOR ALBERTO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	2183,74	1252,61	11		
16/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	36	LCOM	LA CAJA CLIENTES OPEN AUTOS	967	TODO RIESGO C/FQCIA 5% PACK COMODO	B055202	BARREIRO, LAURA VANESA	GRUPO VERÓN SEGUROS	5090	18542201	17/09/2022	17/10/2022	V	451766	Debito	4517660089026790	20442855	D	36859957	BARRERA MORALES, GONZALO NICOLAS	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	6890	5525,01	7		
03/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	34	TRFOMO	OPEN  MARKET CLIENTE - MOTOS	A	RESPONSABILIDAD CIVIL	B053888	STRYCHARSKI, INTI JACQUES	GRUPO FERNANDEZ SEGUROS	1969269	390	03/10/2022	03/04/2023	V	451766	Debito	4517660145795300	60430305	D	39492864	VILLAR SOILAN, FRANCO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	828	276,33	1		
04/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	33	OMCSA	SANCOR OPEN MARKET CLIENTES	TC1	TERCEROS COMPLETO PREMIUM MAX	B055701	ALEMAN, ALEJANDRO	GRUPO ACOSTA SEGUROS	1141	128	04/10/2022	04/04/2023	V	451766	Debito	4517660145804600	80428275	D	25836942	FERNANDEZ,MARIA ISABEL	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	9644,33	6705,81	1		
20/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B041776	ODDONETTO, TAMARA	GRUPO TORRES SEGUROS	31	913424	20/09/2022	20/11/2022	V	451766	Debito	4517660146908030	20215554	D	31685190	ZUCKERMANN,NICOLAS FEDERICO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1538,46	1890	1		
21/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	18	VD0013	VIDA CC	COMPL	VIDA A TU MEDIDA	B057982	CONTRERAS, DANIEL	GRUPO PALERMO SEGUROS	300100	120901	21/09/2022	21/09/2023	V	451766	Debito	4517660153893800	20761566	Q	95822557	SALAZAR CASTILLO,NILEN GABRIELA	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1636,07	2439,47	1	No contesta	
14/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	18	VD0013	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B054186	BERNAL ESPINOZA, LILIANA CAROLINA	GRUPO TELLO SEGUROS	300100	120518	13/09/2022	13/11/2022	V	451766	Debito	4517660154409290	20982640	D	33977511	GRANEL ARAOS,RODRIGO NICOLAS	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1640,8	2446,52	1		
13/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	33	OMCSA	SANCOR OPEN MARKET CLIENTES	TRCF4	TODO RIESGO FCIA. $125.000	B058592	GONZALEZ, EZEQUIEL MARTIN	GRUPO GERABERT SEGUROS	1138	9449	13/09/2022	13/03/2023	V	451766	Debito	4517660161292420	91362852	D	24003267	ARROJO,CARLOS ALBERTO	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	23395,17	16144,78	1		
11/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B055910	GUTIERREZ, VALERIA ALEJANDRA	GRUPO VERÓN SEGUROS	31	918480	11/10/2022	11/10/2023	V	451766	Debito	4517660166440310	40905165	D	18343089	GAIA,ROBERTO SERGIO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1923,08	2362,5	1		
13/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B058591	SOSA, ANALIA EDIT	GRUPO GERABERT SEGUROS	31	919313	13/10/2022	13/10/2023	V	451766	Debito	4517660167693730	40912725	D	32336158	LAGOS LAMAS,ROBERTO MARTIN	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	3307,69	4063,5	1		
06/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B050266	QUINTEROS, PATRICIA LORENA	GRUPO ACOSTA SEGUROS	31	910123	06/09/2022	06/11/2022	V	451766	Debito	4517660168014110	50914925	D	23514113	ROMERO,ARIEL ALBERTO	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	6192,31	7607,25	1		
06/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	18	VD0013	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B050266	QUINTEROS, PATRICIA LORENA	GRUPO ACOSTA SEGUROS	300100	119941	06/09/2022	06/11/2022	V	451766	Debito	4517660168014110	50914925	D	23514113	ROMERO,ARIEL ALBERTO	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	3930,25	5860,22	1		
12/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	37	SCOMM	SAN CRISTOBAL MOTOS OPEN MARKET	C	PREMIUM	B059635	GAETÁN, CANDELA AZUL	GRUPO PALERMO SEGUROS	1,05213E+12	21	12/10/2022	12/04/2023	V	451766	Debito	4517660168014110	50914925	D	23514113	ROMERO, ARIEL ALBERTO	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	2629,83	1863,43	1	No contesta	
14/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	25	PCAR04	PROTECCION CARTERA	PLAN D	PROTECCIÓN CARTERA FULL	B059081	MARTINEZ, ANALIA DEL PILAR	GRUPO PALERMO SEGUROS	500546	0	14/10/2022	14/10/2023	V	451766	Debito	4517660170348230	20594160	D	18409872	BORDA,LAURA ISABEL	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	680,06	551,1	1	No se puede cargar	La cliente tiene dos cuentas en el banco , la cuenta que tiene moviminetos y plata para que se debite el seguro , no sale en sistema para poner dicha cuenta como medio de pago ( No tiene tc)
01/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	18	VD0013	VIDA CC	COMPL	VIDA A TU MEDIDA	B054186	BERNAL ESPINOZA, LILIANA CAROLINA	GRUPO TELLO SEGUROS	300100	119776	01/09/2022	01/11/2022	V	451766	Debito	4517660171688110	20723604	D	38848258	WINTECKER,JUAN IGNACIO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1103,23	1644,98	1		
17/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	18	VD0016	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B058834	CAPORALETTI, EZEQUIEL NICOLAS	GRUPO DIETZ SEGUROS	300100	122338	17/10/2022	17/10/2023	V	451766	Debito	4517660172143890	80668521	Q	94553750	AGUILERA,DERLIS ARIEL	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	2706,46	4035,48	1		
17/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B058834	CAPORALETTI, EZEQUIEL NICOLAS	GRUPO DIETZ SEGUROS	31	920004	17/10/2022	17/10/2023	V	451766	Debito	4517660172143890	80668521	Q	94553750	AGUILERA,DERLIS ARIEL	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1346,16	1653,75	1		
17/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	18	VD0013	VIDA CC	COMPL	VIDA A TU MEDIDA	B048261	GRANJA, FERNANDA GISELLE	GRUPO FERNANDEZ SEGUROS	300100	122283	17/10/2022	17/10/2023	V	451766	Debito	4517660172656730	50941013	D	33452626	BOGADIN,VICTOR JAVIER	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1636,07	2439,47	1		
17/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B058842	LOPARDO, THOMAS ELIAS	GRUPO FERNANDEZ SEGUROS	31	919937	17/10/2022	17/10/2023	V	451766	Debito	4517660173280150	7706319	D	17086812	CAMARGO,ROSA INES	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1153,85	1417,5	1		
29/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B057175	ZERPA, LUCA	GRUPO ACOSTA SEGUROS	31	916139	29/09/2022	29/09/2023	V	451766	Debito	4517660173772190	60949746	D	26463293	ULLOA,VERONICA	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1923,08	2362,5	1		
06/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B055202	BARREIRO, LAURA VANESA	GRUPO VERÓN SEGUROS	31	909843	05/09/2022	05/11/2022	V	451766	Debito	4517660175252090	20981193	D	41656893	ECHEVARRIA,JULIAN EMANUEL	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1153,85	1417,5	1		
01/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B059328	GONZALEZ, SHIRLEY MACARENA	GRUPO ACOSTA SEGUROS	31	909367	01/09/2022	01/11/2022	V	451766	Debito	4517660176111600	10967817	D	40750850	CASTELLI,LORENA ANABELLA	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1538,46	1890	1		
17/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B059648	ALCARAZ, PABLO NAHUEL	GRUPO DIETZ SEGUROS	31	920007	17/10/2022	17/10/2023	V	451766	Debito	4517660176380080	6788989	D	36148568	TOLEDO MAYRA,AYELEN	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1538,46	1890	1		
16/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	18	VD0013	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B056187	SORIA, MARIA LAURA	GRUPO PALERMO SEGUROS	300100	120721	16/09/2022	16/11/2022	V	451766	Debito	4517660176667100	71705499	D	25922612	ACOSTA,DANIEL GUSTAVO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	2393,55	3568,91	1	No contesta	Tel inhabilitado
13/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B053334	ROMERO, KAREN NATALI	GRUPO FERNANDEZ SEGUROS	31	911679	13/09/2022	13/11/2022	V	451766	Debito	4517660176875950	70170847	D	20757040	NU#EZ,EDGARDO LORENZO	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1923,08	2362,5	1		
30/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	18	VD0013	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B059635	GAETÁN, CANDELA AZUL	GRUPO PALERMO SEGUROS	300100	121502	30/09/2022	30/09/2023	V	451766	Debito	4517660177680500	60231530	D	29473607	CALDERON,CARLOS MARTIN	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	2006,94	2992,46	1	No contesta	
04/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	18	VD0013	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B053763	OJALVO, JULIETA	GRUPO ARCE SEGUROS	300100	121703	04/10/2022	04/10/2023	V	451766	Debito	4517660177998880	20773248	D	37063050	SOBERON,MAURICIO DAMIAN	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1374,39	2049,29	1		
22/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	33	OMCSA	SANCOR OPEN MARKET CLIENTES	TRCF3	TODO RIESGO FCIA. $70.000	B053888	STRYCHARSKI, INTI JACQUES	GRUPO FERNANDEZ SEGUROS	1139	7700	22/09/2022	22/03/2023	V	451766	Debito	4517660912106690	90161397	D	34271566	BOLLER,HERNAN JOSE MIGUEL	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	13648,33	9404,53	1		
20/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	18	VD0013	VIDA CC	COMPL	VIDA A TU MEDIDA	B057099	FRANCO, ANTONELLA BARBARA	GRUPO PALERMO SEGUROS	300100	120837	05/10/2022	05/10/2023	V	451766	Debito	4517660914992900	30470375	D	23137086	LOPEZ,SANDRA RAMONA	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	2629,53	3920,78	1	No contesta	Atinde y corta cuando le informanos que nos comunicamos del banco
20/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	25	PCAR04	PROTECCION CARTERA	PLAN D	PROTECCIÓN CARTERA FULL	B057099	FRANCO, ANTONELLA BARBARA	GRUPO PALERMO SEGUROS	499042	0	05/10/2022	05/10/2023	V	451766	Debito	4517660914992900	30470375	D	23137086	LOPEZ,SANDRA RAMONA	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	680,06	551,1	1	No contesta	Atinde y corta cuando le informanos que nos comunicamos del banco
30/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	33	OPASSA	SANCOR CLIENTES PAS	TRCF4	TODO RIESGO FCIA. $125.000	B053888	STRYCHARSKI, INTI JACQUES	GRUPO FERNANDEZ SEGUROS	1140	8220	30/09/2022	31/03/2023	V	451766	Debito	4517660916201600	10873610	D	35665249	ANGILERI,JOSE LUIS ANTONIO	2	INDIVIDUO	INDIVIDUOS - RENTA MEDIA	11341,83	7797,67	1		
18/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	973	973	18	VD0013	VIDA CC	FAMIL	VIDA FAMILIA PROTEGIDA	B054286	CORDOVA, CLARA ROMINA	GRUPO ARCE SEGUROS	300100	122393	18/10/2022	18/10/2023	V	451766	Debito	4517660916659190	71625426	D	38989841	SANCHEZ,EUNICE ANGELA MICAELA	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1640,8	2446,52	1		
13/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	21	HG0031	VIVIENDA MENSUAL	1VIV	1ERA VIVIENDA	B055202	BARREIRO, LAURA VANESA	GRUPO VERÓN SEGUROS	5107436	0	13/09/2022	13/09/2023	V	451766	Debito	4517660916755930	6966758	D	37848758	GOMEZ SADA,JUAN CARLOS	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	2656,99	3229,73	1		
08/09/2022	EMISION	SEBOK	CALL CENTER EXTERNO	999	914	33	OMCSA	SANCOR OPEN MARKET CLIENTES	TC1	TERCEROS COMPLETO PREMIUM MAX	B056187	SORIA, MARIA LAURA	GRUPO PALERMO SEGUROS	1134	7039	08/09/2022	08/03/2023	V	451766	Debito	4517660917148130	10082203	D	29812853	SALAZAR PALACIO,SERGIO ADRIAN	1	INDIVIDUO	INDIVIDUOS - RENTA ALTA	8579,33	5911,65	11	seguimiento	No figura el modelo del auto , el cliente lo va a chequear nuevamente 
19/10/2022	EMISION	SEBOK	CALL CENTER EXTERNO	901	901	1	AP0001	ACC. PERSONALES OPEN MARKET	24	PLAN PLUS MENSUAL	B055910	GUTIERREZ, VALERIA ALEJANDRA	GRUPO VERÓN SEGUROS	31	920584	19/10/2022	19/10/2023	V	451766	Debito	4517660917655020	60782791	D	36286510	VILLALBA,MARIELA SOLEDAD	3	INDIVIDUO	INDIVIDUOS - RENTA MASIVA	1153,85	1417,5	11		

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
    
