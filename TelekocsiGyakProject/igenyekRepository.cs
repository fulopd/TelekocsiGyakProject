using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekocsiGyakProject
{
    class igenyekRepository
    {

        public List<Igeny> igenyekLista { get; }

        public igenyekRepository()
        {
            igenyekLista = new List<Igeny>();
            Beolvas();
        }

        void Beolvas()
        {
            using (var sr = new StreamReader("forras/igenyek.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');
                    igenyekLista.Add(new Igeny(
                                    sor[0],
                                    sor[1],
                                    sor[2],                                    
                                    Convert.ToInt32(sor[3])
                        ));
                }
            }
        }

    }
}
