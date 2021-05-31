using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class Helper
    {
        public static int validarNroMenu()
        {
            bool validar = false;
            int numero;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Ingrese una opcion valida");
                }
                if (!numero.Equals(1) && !numero.Equals(9) && !numero.Equals(2) && !numero.Equals(3) )
                {
                    Console.WriteLine("Favor de ingresar una opcion valida");
                }
                else validar = true;

            } while (!validar);
            return numero;
        }

        public static int ValidarNumero()
        {
            bool validar = false;
            int numero;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Favor de ingresar un numero");
                }
                if (numero < 0)
                    Console.WriteLine("No puede ingresar un numero negativo.");
                else validar = true;
                

            } while (!validar);
            return numero;
        }

        public static DateTime DameFecha()
        {
            bool ok = false;
            DateTime fecha;
            do
            {
                var ingreso = Console.ReadLine();
                if (!DateTime.TryParse(ingreso, out fecha))
                {
                    Console.WriteLine("Fecha invalida");
                    continue;
                }

                if (fecha > DateTime.Now)
                {
                    Console.WriteLine("la fecha debe ser menor a la actual");
                    continue;
                }
                ok = true;
            } while (!ok);
            return fecha;
        }
        //public static bool volverMenu()
        //{
        //    Console.WriteLine("¿Desea volver al menu principal?");
        //    Console.WriteLine("Ingrese 1 para volver. ")
        //}
        
    }
}
