using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ćwiczenie_1
{
    public struct Samochod
    {
        public double Cena;
        public int Rocznik;
        public double Przebieg;
        public string Marka;
    };

    class Program
    {
        static double Wczytaj_Cene()
        {
            double Cena;
            Console.Write("Podaj cenę samochodu: ");
            do
            {
                Cena = Convert.ToDouble(Console.ReadLine());
                if (Cena < 0) Console.WriteLine("Cena nie może być ujemna. Podaj poprawną wartość: ");
            } while (Cena < 0);
            return Cena;
        }
        static double Wczytaj_Przebieg()
        {
            double przebieg;
            Console.Write("Podaj przebieg: ");
            do
            {
                przebieg = Convert.ToDouble(Console.ReadLine());
                if (przebieg < 0) Console.WriteLine("Przebieg nie może być ujemny. Podaj poprawną wartość: ");
            } while (przebieg < 0);
            return przebieg;
        }

        static int Wczytaj_Rocznik()
        {
            double rocznik;
            Console.Write("Podaj rocznik: ");
            do
            {
                rocznik = Convert.ToDouble(Console.ReadLine());
                if (rocznik < 0) Console.WriteLine("Rocznik nie może być ujemny ani ułamkiem. Podaj poprawną wartość: ");
            } while (rocznik < 0 || (int)rocznik != rocznik);
            return (int)rocznik;
        }

        static string Wczytaj_Marke()
        {
            string marka;
            Console.Write("Podaj marke samochodu: ");
            do
            {
                marka = Console.ReadLine();
                if (!marka.All(Char.IsLetter)) Console.WriteLine("Marka nie może zawierać cyfr. Podaj poprawną wartość: ");
            } while (!marka.All(Char.IsLetter));
            return marka;
        }

        static void Wczytaj_Samochod(ref Samochod element)
        {

            element.Marka = Wczytaj_Marke();
            element.Przebieg = Wczytaj_Przebieg();
            element.Cena = Wczytaj_Cene();
            element.Rocznik = Wczytaj_Rocznik();
        }
        static void Wypisz_Samochod(Samochod element)
        {
            Console.WriteLine("Marka: {0}", element.Marka);
            Console.WriteLine("Przebieg: {0}", element.Przebieg);
            Console.WriteLine("Cena: {0}", element.Cena);
            Console.WriteLine("Rocznik: {0}", element.Rocznik);
        }
        static void Wypisz_Samochody(Samochod[] tablica, int dlug)
        {
            for (int i = 0; i < dlug; i++)
            {
                Console.WriteLine("Samochód nr {0}", i + 1);
                Wypisz_Samochod(tablica[i]);
            }
        }


        static void Zapisz(ref Samochod[] tablica, int dlugosc, string plik)
        {
            StreamWriter Plik = new StreamWriter(plik, false);
            Plik.WriteLine(dlugosc);
            for (int licz = 0; licz < dlugosc; licz++)
            {
                Plik.WriteLine(tablica[licz].Cena);
                Plik.WriteLine(tablica[licz].Rocznik);
                Plik.WriteLine(tablica[licz].Przebieg);
                Plik.WriteLine(tablica[licz].Marka);
            }
            Plik.Close();
        }

        static int Samochody_Zpliku(out Samochod[] tablica, string nazwa_pliku)
        {
            StreamReader Plik = new StreamReader(nazwa_pliku);
            int dlugosc = Convert.ToInt32(Plik.ReadLine());
            tablica = new Samochod[dlugosc];
            for (int i = 0; i < dlugosc; i++)
            {
                tablica[i].Cena = Convert.ToDouble(Plik.ReadLine());
                tablica[i].Rocznik = Convert.ToInt32(Plik.ReadLine());
                tablica[i].Przebieg = Convert.ToInt32(Plik.ReadLine());
                tablica[i].Marka = Plik.ReadLine();
            }
            return dlugosc;
        }

        static void Zamien(ref Samochod s1, ref Samochod s2)
        {
            Samochod tmp;
            tmp.Cena = s1.Cena;
            s1.Cena = s2.Cena;
            s2.Cena = tmp.Cena;
            tmp.Marka = s1.Marka;
            s1.Marka = s2.Marka;
            s2.Marka = tmp.Marka;
            tmp.Przebieg = s1.Przebieg;
            s1.Przebieg = s2.Przebieg;
            s2.Przebieg = tmp.Przebieg;
            tmp.Rocznik = s1.Rocznik;
            s1.Rocznik = s2.Rocznik;
            s2.Rocznik = tmp.Rocznik;
        }

        static void sortuj(ref Samochod[] tablica, int N)
        {
            bool zamiana = false;
            do
            {
                for (int licz = 0; licz < N - 1; licz++)
                    if (tablica[licz].Przebieg > tablica[licz + 1].Przebieg)
                    {
                        Zamien(ref tablica[licz], ref tablica[licz + 1]);
                        zamiana = true;
                    }
            }
            while (zamiana);
        }

        static void Main(string[] args)
        {
            /*           Console.Write("Podaj ilość samochodów: ");
                       int N = Convert.ToInt32(Console.ReadLine());
                       Samochod[] Samochody = new Samochod[N];
                       for (int licz = 0; licz < N; licz++)
                           Wczytaj_Samochod(ref Samochody[licz]);
                       Zapisz(ref Samochody, N, "plik.txt");*/
            Samochod[] Samochody;
            int N = Samochody_Zpliku(out Samochody, "plik.txt");
            sortuj(ref Samochody, N);
            Wypisz_Samochody(Samochody, N);
            Console.ReadKey();
        }
    }
}

