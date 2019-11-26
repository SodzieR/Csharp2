using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw8
{
    class cw8
    {
        public class Prostokat
        {
            private double dlugosc;
            private double szerokosc;
            public Prostokat(double dl, double sz)
            {
                dlugosc = dl;
                szerokosc = sz;
            }
            private double Powierzchnia()
            {
                return dlugosc * szerokosc;
            }
            private double Obwod()
            {
                return 2 * dlugosc + 2 * szerokosc;
            }
            public string Prezentuj()
            {
                return "Obwod: " + Obwod() + ", Powierzchnia: " + Powierzchnia();

            }
        }
        static void Main(string[] args)
        {
            Prostokat p1 = new Prostokat(12, 24);
            Console.WriteLine(p1.Prezentuj());
            Console.ReadKey();
        }
    }
}
