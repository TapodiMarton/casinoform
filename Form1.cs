using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vizsga3_casino
{
    public partial class Form1 : Form
    {
        List<Jatszma> jatszmak = new List<Jatszma>();
        List<Felhasznalo> felhasznalok = new List<Felhasznalo>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("nyeremeny.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Jatszma jatszma_object = new Jatszma(values[0], values[1], values[2], values[3], values[4]);
                jatszmak.Add(jatszma_object);
            }
            List<string> felhasznalokstr = new List<string>();
            foreach (var item in jatszmak)
            {
                if (!felhasznalokstr.Contains(item.felhasznalo))
                {
                    felhasznalokstr.Add(item.felhasznalo);
                }

            }
            foreach (var item in felhasznalokstr)
            {
                Felhasznalo felhasznalo_object = new Felhasznalo(item, jatszmak);
                felhasznalok.Add(felhasznalo_object);
            }
            int maxtet = int.MinValue;
            Felhasznalo max_ertek_user = felhasznalok[0];
            foreach (var item in felhasznalok)
            {
                if (item.sumtet > maxtet)
                {
                    maxtet = item.sumtet;
                    max_ertek_user = item;
                }
            }
            label2.Text = $"Felhasználó: {max_ertek_user.nev}, Tétösszege:{maxtet}";  //2.Feladat

            int vesztes = 0;

            foreach (var item2 in jatszmak)
            {
                if (item2.nyeVve.StartsWith("vesz"))
                {
                    vesztes++;
                }
            }

            label3.Text = $"{vesztes}";    //3.Feladat

            int min_nyeremeyn = int.MaxValue;  //4.Feladat

            Jatszma min_ertek = jatszmak[0];

            foreach (var item in jatszmak)
            {
                if (min_nyeremeyn > item.nyeremeny)
                {
                    min_nyeremeyn = item.nyeremeny;
                    min_ertek = item;
                }
            }
            label4.Text = $"{min_ertek.sorszam} {min_ertek.felhasznalo} tet: {min_ertek.tet} szorzo: {min_ertek.szorzo} , nyerem:{min_ertek.nyeremeny}";

            string a_fel = "";
            int adb = 0;
            foreach (var item in felhasznalokstr)
            {
                if (item.StartsWith("a"))
                {
                    adb++;
                    if (adb < 6)
                    {
                        a_fel += item + " ;";
                    }
                }

            }
            label5.Text = $"A:db: {adb}, { a_fel}, ";
            foreach (var item in felhasznalok)

            {
                if (item.nev == "decongen")
                    label6.Text = " Decongen össz nyereménye: " + item.sumnyer;         //6 Feladat
            }
            int nyer = 0;
            foreach (var item in jatszmak)
            {
                if (item.nyeVve.StartsWith("ny"))
                {

                    nyer += item.tet;
                }
            }
            label7.Text = "Összes nyertes tét összege: " + nyer;

            foreach (var item in jatszmak)
            {
                if (item.nyeVve.StartsWith("ny"))
                {
                    dataGridView2.Rows.Add(item.sorszam, item.felhasznalo, item.nyeremeny, item.nyeVve);   //5
                }
            }
        }

        // 1.Feladat
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in jatszmak)
                if (numericUpDown1.Value == item.sorszam)
                {
                    if (item.nyeVve.StartsWith("ny"))
                    {
                        label1.Text = $"Sorszám: {item.sorszam}, Név: {item.felhasznalo}, Tét: {item.tet}, Szorzó: {item.szorzo}, Nyert-e:{item.nyeVve} Nyeremény:{item.nyeremeny}";
                    }
                    else
                    {
                        label1.Text = $"Sorszám: {item.sorszam}, Név: {item.felhasznalo}, Tét: {item.tet}, Szorzó: {item.szorzo}, Nyerte-e: {item.nyeVve}: Nyeremény: 0";
                    }
                }
        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            foreach (var item in felhasznalok)
            {
                if (textBox2.Text.ToLower() == item.nev)
                {
                    foreach (var item2 in item.jatszmak_lista)
                    {
                        if (item2.nyeVve.StartsWith("ny"))
                        {
                            dataGridView1.Rows.Add(item2.sorszam, item2.felhasznalo, item2.tet, item2.szorzo, item2.nyeremeny, item2.nyeVve);
                        }
                        else
                        {
                            dataGridView1.Rows.Add(item2.sorszam, item2.felhasznalo, item2.tet, item2.szorzo, "0", item2.nyeVve);
                        }
                    }
                }
            }
        }
    }
}
