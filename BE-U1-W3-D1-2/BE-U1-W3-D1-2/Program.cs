using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(int, string, double)> menu = new List<(int, string, double)>()
                {
                    (1, "Coca Cola 150 ml", 2.50),
                    (2, "Insalata di pollo", 5.20),
                    (3, "Pizza Margherita", 10.00),
                    (4, "Pizza 4 Formaggi", 12.50),
                    (5, "Pz patatine fritte", 3.50),
                    (6, "Insalata di riso", 8.00),
                    (7, "Frutta di stagione", 5.00),
                    (8, "Pizza fritta", 5.00),
                    (9, "Piadina vegetariana", 6.00),
                    (10, "Panino Hamburger", 7.90)
                };

            List<(int, string, double)> ordini = new List<(int, string, double)>();

            while (true)
            {
                Console.WriteLine("==============MENU==============");
                foreach (var item in menu)
                {
                    Console.WriteLine($"{item.Item1}: {item.Item2} ({item.Item3})");
                }
                Console.WriteLine("11: Stampa conto finale e conferma");
                Console.WriteLine("==============MENU==============");

                Console.WriteLine("Inserisci il numero del cibo da ordinare:");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int scelta) || scelta < 1 || scelta > 11)
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                    continue;
                }

                if (scelta == 11)
                {
                    Console.WriteLine("Conto finale:");
                    foreach (var ordine in ordini)
                    {
                        Console.WriteLine($"{ordine.Item2} ({ordine.Item3})");
                    }
                    double totale = CalcolaTotale(ordini);
                    Console.WriteLine($"Servizio al tavolo (3.00)");
                    Console.WriteLine($"Totale da pagare: {totale + 3.00}");
                    Console.WriteLine("Grazie per aver ordinato!");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    ordini.Add(menu[scelta - 1]);
                    Console.WriteLine($"{menu[scelta - 1].Item2} aggiunto all'ordine.");
                }
            }
        }

        static double CalcolaTotale(List<(int, string, double)> ordini)
        {
            double totale = 0;
            foreach (var ordine in ordini)
            {
                totale += ordine.Item3;
            }
            return totale;
        }
    }
}
