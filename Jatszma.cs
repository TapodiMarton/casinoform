using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsga3_casino
{
    internal class Jatszma
    {
        public int sorszam;
        public string felhasznalo;
        public int tet;
        public int szorzo;
        public string nyeVve;
        public int nyeremeny;

        public Jatszma(string sorszam, string felhasznalo, string tet, string szorzo, string nyeVve)
        {
            this.sorszam = int.Parse(sorszam);
            this.felhasznalo = felhasznalo;
            this.tet = int.Parse(tet);
            this.szorzo = int.Parse(szorzo);
            this.nyeVve = nyeVve;
            this.nyeremeny = int.Parse(tet) * int.Parse(szorzo);
        }
    }
}
