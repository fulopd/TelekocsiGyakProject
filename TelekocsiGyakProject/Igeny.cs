using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekocsiGyakProject
{
    class Igeny
    {
        //Azonosító;Indulás;Cél;Személyek
        //B34019; Brassó;Gyula;3
        public string azonosito { get; set; }
        public string indulas { get; set; }
        public string cel { get; set; }
        public int szemelyek { get; set; }
        public string indulCel { get; set; }
        public Igeny(string azonosito, string indulas, string cel, int szemelyek)
        {
            this.azonosito = azonosito;
            this.indulas = indulas;
            this.cel = cel;
            this.szemelyek = szemelyek;
            indulCel = indulas + "-" + cel;
        }

    }
}
