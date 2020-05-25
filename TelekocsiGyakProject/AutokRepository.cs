using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekocsiGyakProject
{
    class AutokRepository
    {
        List<Auto> autokLista;

        public AutokRepository()
        {
            autokLista = new List<Auto>();
            Beolvas();
        }

        private void Beolvas()
        {
            using (var sr = new StreamReader("forras/autok.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');
                    autokLista.Add(new Auto(
                                    sor[0],
                                    sor[1],
                                    sor[2],
                                    sor[3],
                                    Convert.ToInt32(sor[4])
                        ));
                }
            }
        }

        public int Count()
        {
            return autokLista.Count();
        }


        public int GetBudepastMiskolcFerohelyekSzama()
        {
            return autokLista.Where(x => x.indulas.Equals("Budapest") && x.cel.Equals("Miskolc")).Sum(x => x.ferohely);
        }


        public void GetLegtobbFerohely()
        {
            var fero = autokLista.GroupBy(x => x.indulCel).Select(g => new {
                                                                            Key = g.Key,
                                                                            Value = g.Sum(s => s.ferohely)
                                                                            }).OrderByDescending(x=> x.Value).ToList();
            //fero.ForEach(x => Console.WriteLine(x.Key + " - " +x.Value));
            Console.WriteLine("\tA legtöbb férőhely ({0}) a {1} útvonalon ajánlották fel a hirdetők",fero[0].Value, fero[0].Key);
        }


        public void IgenyekEgyeztetese()
        {
            igenyekRepository irepo = new igenyekRepository();
            List<Igeny> igenyekLista = irepo.igenyekLista;
            List<Auto> tempAutoLista = autokLista;

            using (var sw = new StreamWriter("utasuzenetek.txt", false, Encoding.UTF8))
            {
                foreach (Igeny igeny in igenyekLista)
                {
                    string uszenet = igeny.azonosito +": Sajnos nem sikierült autót találni";
                    foreach (Auto auto in tempAutoLista)
                    {
                        if (igeny.indulCel == auto.indulCel && auto.ferohely >= igeny.szemelyek)
                        {
                            Console.WriteLine("\t{0} => {1} / {2,-30} - {3,-30} / {4} - {5}", igeny.azonosito, auto.rendszam, igeny.indulCel, auto.indulCel, igeny.szemelyek, auto.ferohely);
                            uszenet = igeny.azonosito + ": Rendszám: "+auto.rendszam+", Telefonszám:"+auto.telefonszam;
                            tempAutoLista.Remove(auto);
                            break;
                        }

                    }
                    sw.WriteLine(uszenet);
                }
            }

            
        }
    }
}
