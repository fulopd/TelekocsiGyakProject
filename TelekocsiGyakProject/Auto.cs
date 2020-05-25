using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekocsiGyakProject
{
    class Auto
    {
        //Indulás;Cél;Rendszám;Telefonszám;Féröhely
        //Eger; Salgótarján;PQA-209;30/771-8574;5
        public string indulas { get; set; }
        public string cel { get; set; }
        public string rendszam { get; set; }
        public string telefonszam { get; set; }
        public int ferohely { get; set; }
        public string indulCel { get; set; }

        public Auto(string indulas, string cel, string rendszam, string telefonszam, int ferohely)
        {
            this.indulas = indulas;
            this.cel = cel;
            this.rendszam = rendszam;
            this.telefonszam = telefonszam;
            this.ferohely = ferohely;
            indulCel = indulas + "-" + cel;
        }

        


    }
}
