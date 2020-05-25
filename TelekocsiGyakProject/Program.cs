using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekocsiGyakProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. feladat
            AutokRepository autokRepo = new AutokRepository();

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine("\t{0} autós hirdet fuvart",autokRepo.Count());

            //3.feladat
            Console.WriteLine("\n3. feladat");
            Console.WriteLine("\tÖsszesen {0} férőhelyet hírdettek az autósok budapestről Miskolcra",autokRepo.GetBudepastMiskolcFerohelyekSzama());

            //4. feladat
            Console.WriteLine("\n4. feladat");
            autokRepo.GetLegtobbFerohely();

            //5. felada
            Console.WriteLine("\n5. feladat");
            autokRepo.IgenyekEgyeztetese();

            Console.ReadKey();
        }
    }
}
