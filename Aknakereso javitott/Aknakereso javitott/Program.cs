using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso_javitott
{
    class Program
    {

        static void Main(string[] args)
        {
            char[,] pálya = new char[10, 10];
            Feltöltés(pálya);
            Bombasorsoló(pálya);
            Kirajzoló(pálya, false);
            int lépx;
            int lépy;
            do
            {
                Lépés(pálya, out lépx, out lépy);
            } while (pálya[lépx, lépy] != 'B');
            Console.ReadKey();
        }

        static void Feltöltés(char[,] pálya)
        {

            for (int i = 0; i < pálya.GetLength(0); i++)
            {
                for (int j = 0; j < pálya.GetLength(1); j++)
                {
                    pálya[i, j] = '_';
                }
            }
        }

        static void Lépés(char[,] pálya, out int lépx, out int lépy)
        {
            Console.WriteLine("Kérem az oszlopszámot.");
            lépy = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Kérem a sorszámot.");
            lépx = int.Parse(Console.ReadLine()) - 1;
            if (pálya[lépx, lépy] == 'B')
            {
                Kirajzoló(pálya, false);
                Console.WriteLine("Felrobbantál.");
            }

            else
            {
                pálya[lépx, lépy] = 'X';
                pálya[lépx, lépy] = '|';
                pálya[lépx, lépy] = '_';
                Kirajzoló(pálya, false);
            }

            int db = 0;

            for (int i = 0; i < 'X'; i++)
            {
                for (int j = 0; j < 'B' + 1; j++)
                {
                    db++;
                }
            }
            if (db == 'B')
            {
                Console.WriteLine($"{db} db bomba van a szomszédjában.");

            }
            else
            {
                Console.WriteLine("Nincs bomba a szomszédjában.");
            }



        }

        static void Bombasorsoló(char[,] pálya)
        {
            Random gép = new Random();
            Console.WriteLine("Add meg a bombaszámot.");
            int bombaszám = int.Parse(Console.ReadLine());
            int sor;
            int oszlop;
            for (int i = 0; i < bombaszám; i++)
            {
                do
                {
                    sor = gép.Next(10);
                    oszlop = gép.Next(10);
                } while (pálya[sor, oszlop] == 'B');
                pálya[sor, oszlop] = 'B';
            }
        }

        static void Kirajzoló(char[,] pálya, bool legyenbomba)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
            {
                for (int j = 0; j < pálya.GetLength(1); j++)
                {
                    if (legyenbomba)
                    {
                        Console.Write(pálya[i, j]);
                    }
                    else if (pálya[i, j] != 'X')
                    {
                        Console.Write('_');
                    }
                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }
    }
}
