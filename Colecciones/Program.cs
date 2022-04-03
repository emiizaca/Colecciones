using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Colecciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ejercicio4();
        }

        private static void Ejercicio1()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("Juan", "55423412");
            values.Add("Ernesto", "56985623");
            values.Add("Mariana", "54787451");

            if (values.ContainsKey("Juan"))
            {
                Console.WriteLine(values["Juan"]);
            }

            string salida = null;
            if (values.TryGetValue("Pedro", out salida))
            {
                Console.WriteLine(values["Pedro"]);
            }
            else
            {
                Console.WriteLine("No contiene la llave.");
            }

            foreach (KeyValuePair<string, string> kvp in values)
            {
                Console.WriteLine("indice: " + kvp.Key + "| valor: " + kvp.Value);
            }

            values["Mariana"] = "58251425";
            Console.WriteLine(values["Mariana"]);
        }

        private static void Ejercicio2()
        {
            string[] colors = { "MAGENTA", "RED", "WHITE", "BLUE", "CYAN" };
            string[] removeColors = { "RED", "WHITE", "BLUE" };

            List<string> lstColors = new List<string>(colors);
            List<string> lstRemoveColors = new List<string>(removeColors);

            foreach (string color in lstColors)
            {
                Console.WriteLine(color);
            }

            lstColors.RemoveAll(color => lstRemoveColors.Contains(color));

            foreach(string color in lstColors)
            {
                Console.WriteLine(color);
            }
        }

        private static void Ejercicio3()
        {
            Console.WriteLine("Ingrese un parrafo: ");
            string parrafo = Console.ReadLine();
            List<string> palabras = new List<string>(parrafo.Split(' '));
            foreach (var i in palabras.GroupBy(x => x))
            {
                Console.WriteLine(i.Key + " aparece " + i.Count() + " veces.");
            }
        }

        private static void Ejercicio4()
        {
            String linea;
            Dictionary<string, int> cantidadVotaciones = new Dictionary<string, int>();
            try
            {
                StreamReader archivo = new StreamReader(@"C:\Users\emiiz\Desktop\ratings.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    List<string> usuarios = new List<string>(linea.Split(','));
                    if (cantidadVotaciones.ContainsKey(usuarios[1]))
                    {
                        cantidadVotaciones[usuarios[1]]++;
                    }
                    else
                    {
                        cantidadVotaciones.Add(usuarios[1], 1);
                    }
                    linea = archivo.ReadLine();
                }
                foreach (KeyValuePair<string, int> kvp in cantidadVotaciones.OrderByDescending(o => o.Value).Where(w => w.Value > 500))
                {
                    Console.WriteLine("Usuario: " + kvp.Key + " tiene " + kvp.Value + " votaciones.");
                }

                archivo.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
