using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyumolcsBolt
{
    class Program
    {
        static void Main()
        {
            Aru[] aruk = new Aru[5];
            
            aruk[0] = new Gyumolcs { Nev = "Alma", Ar = 100, Mennyiseg = 2, Mertekegyseg = Egyseg.kg, Friss = true };
            aruk[1] = new Gyumolcs { Nev = "Narancs", Ar = 80, Mennyiseg = 1, Mertekegyseg = Egyseg.kg, Friss = false };
            aruk[2] = new Udito { Nev = "Coca-Cola", Ar = 120, Mennyiseg = 2, Mertekegyseg = Egyseg.l, GyumolcsTartalomSzazalek = 0 };
            aruk[3] = new Udito { Nev = "Almalé", Ar = 100, Mennyiseg = 1, Mertekegyseg = Egyseg.l, GyumolcsTartalomSzazalek = 40 };

            Console.WriteLine("Új elemek beolvasása: (leállitáshoz használja a * karaktert):");
            ReadNewElements(aruk);

            Console.WriteLine("\nCsak gyümölcsök:");
            PrintOnlyGyumolcs(aruk);

            Console.WriteLine("\nCsak üdítők:");
            PrintOnlyUdito(aruk);

            Console.WriteLine("\nÜdítők gyümölcstartalma valós mennyiségben:");
            PrintUditoGyumolcsMennyiseg(aruk);
        }
        static void ReadNewElements(Aru[] aruk)
        {
            int index = getNextIndex(aruk);
            while (index < aruk.Length)
            {   
                Console.Write("Név: ");
                string nev = Console.ReadLine();
                if (nev == "*")
                    break;

                Console.Write("Ár: ");
                decimal ar;
                while (!decimal.TryParse(Console.ReadLine(), out ar))
                {
                    Console.WriteLine("Hibás adat! Kérem adjon meg egy érvényes árat.");
                }

                Console.Write("Mennyiség: ");
                decimal mennyiseg;
                while (!decimal.TryParse(Console.ReadLine(), out mennyiseg))
                {
                    Console.WriteLine("Hibás adat! Kérem adjon meg egy érvényes mennyiséget.");
                }

                Console.Write("Mértékegység (dl, l, g, kg): ");
                string mertekegysegStr = Console.ReadLine();
                Egyseg mertekegyseg;
                Enum.TryParse(mertekegysegStr, out mertekegyseg);

                if (mertekegyseg == Egyseg.dl || mertekegyseg == Egyseg.l)
                {
                    Console.Write("Gyümölcs százalék: ");
                    int gyumolcstartalomszazalek;
                    while (!int.TryParse(Console.ReadLine(), out gyumolcstartalomszazalek))
                    {
                        Console.WriteLine("Hibás adat! Kérem adjon meg egy érvényes mennyiséget.");
                    }
                    aruk[index] = new Udito { Nev = nev, Ar = ar, Mennyiseg = mennyiseg, Mertekegyseg = mertekegyseg, GyumolcsTartalomSzazalek = gyumolcstartalomszazalek};
                }
                else
                {
                    aruk[index] = new Gyumolcs { Nev = nev, Ar = ar, Mennyiseg = mennyiseg, Mertekegyseg = mertekegyseg, Friss = true};
                }
                index = getNextIndex(aruk);
            }
        }
        static void PrintOnlyGyumolcs(Aru[] aruk)
        {
            foreach (var aru in aruk)
            {
                if (aru is Gyumolcs gyumolcs)
                {
                    Console.WriteLine(gyumolcs);
                }
            }
        }
        static void PrintOnlyUdito(Aru[] aruk)
        {
            foreach (var aru in aruk)
            {
                if (aru is Udito udito)
                {
                    Console.WriteLine(udito);
                }
            }
        }
        static void PrintUditoGyumolcsMennyiseg(Aru[] aruk)
        {
            foreach (var aru in aruk)
            {
                if (aru is Udito udito)
                {
                    Console.WriteLine($"{udito.Nev} gyümölcstartalom: {udito.GetGyumolcsMennyiseg()} {udito.Mertekegyseg}");
                }
            }
        }
        static int getNextIndex(Aru[] aruk)
		{
            for (int i = 0; aruk.Length > i; i++)
			{
                if(aruk[i] is null)
				{
                    return i;
				}
			}
            return aruk.Length;
		}
    }
    public enum Egyseg
	{
		dl,
		l,
		g,
		kg
	}
}
