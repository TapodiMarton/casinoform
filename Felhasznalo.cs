using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsga3_casino
{
    internal class Felhasznalo
    {
        public string nev;
        public List<Jatszma> jatszmak_lista;
        public int db;
        public int sumtet;
        public int SUM_kedv;
        public int sumnyer;
        public Felhasznalo(string nev, List<Jatszma> megrendelesek)
        {
            this.nev = nev;
            this.jatszmak_lista = Listaz(megrendelesek);
            this.db = megrendelesek.Count;
            this.sumtet = Szamol_ar(megrendelesek);
            this.SUM_kedv = Szamol_kedv(megrendelesek);
            this.sumnyer = Szamol_fiz(megrendelesek);
        }

        public List<Jatszma> Listaz(List<Jatszma> megrendelesek)
        {
            List<Jatszma> lista = new List<Jatszma>();
            foreach (var item in megrendelesek)
            {
                if (item.felhasznalo == nev)
                {
                    lista.Add(item);
                }
            }
            return lista;

        }
        public int Szamol_ar(List<Jatszma> megrendelesek)
        {
            int sum = 0;
            foreach (var item in megrendelesek)
            {
                if (item.felhasznalo == nev)
                {
                    sum += item.tet;
                }
            }
            return sum;
        }
        public int Szamol_kedv(List<Jatszma> megrendelesek)
        {
            int sum = 0;
            foreach (var item in megrendelesek)
            {
                if (item.felhasznalo == nev)
                {
                    sum += item.szorzo;
                }
            }
            return sum;
        }
        public int Szamol_fiz(List<Jatszma> megrendelesek)
        {
            int sum = 0;
            foreach (var item in megrendelesek)
            {
                if (item.felhasznalo == nev && item.nyeVve.StartsWith("ny"))
                {
                    sum += item.nyeremeny;
                }
            }
            return sum;
        }


    }
}
