using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLavoratori
{
    [Serializable]
    enum Genere
    {
        M,
        F,
        G
    }
    enum TitoloDiStudio
    {
        LicenzaElementare,
        LicenzaMedia,
        DiplomaSuperiore,
        Laurea,
        Dottorato
    }
    class Lavoratori
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Genere Sesso{ get; set; }
        public TitoloDiStudio Titolo{get; set;}
        public DateTime DataDiNascita { get; set; }
        public DateTime DataAssunzione { get; set; }
        public int Età { get; set; }
        public int AnniServizio { get; set; }
        public int StipendioMensile { get; set; }
        public int Mensilità { get; set; }
        public int RAL { get; set; }
        public Lavoratori(){ }

        public virtual int CalcolaAnni(DateTime start)
        {
            return DateTime.Now.Year - start.Year;
        }
        public Lavoratori(string nome, string cognome, DateTime nascita, Genere genere, TitoloDiStudio titolo, DateTime assunzione, 
            int stipMensile, int mensilità)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = nascita;
            DataAssunzione = assunzione;
            Età = CalcolaAnni(DataDiNascita);
            AnniServizio = CalcolaAnni(DataAssunzione);
            Sesso = genere;
            Titolo = titolo;
            StipendioMensile = stipMensile;
            Mensilità = mensilità;
            RAL = StipendioMensile * Mensilità;
        }
        public DateTime InserisciData()
        {
            int gg = 0, mm = 0, aa = 0;
            try
            {
                Console.WriteLine("Giorno");
                gg = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Mese");
                mm = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Anno");
                aa = Int32.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Formato non valido, riprova.");
            }
            

            DateTime data = new DateTime(aa, mm, gg);
            return data;
        }
        public Lavoratori InsertWorker(Lavoratori worker)
        {
            int scelta = 0;
            Console.WriteLine("Nome: ");
            worker.Nome = Console.ReadLine();
            Console.WriteLine("Cognome: ");
            worker.Cognome = Console.ReadLine();
            Console.WriteLine("Genere (0 per Maschio, 1 per femmina, 2 per Gender): ");
            scelta = Int32.Parse(Console.ReadLine());
            if(scelta == 0)
            {
                worker.Sesso = Genere.M;
            }
            else if (scelta == 1)
            {
                worker.Sesso = Genere.F;
            }
            else if (scelta == 2)
            {
                worker.Sesso = Genere.G;
            }
            Console.WriteLine("Titolo di Studio \n " +
                "(0 per Licenza Elementare, 1 per Licenza Media, 2 per Diploma Superiore, 3 per Laurea, 4 per Dottorato): ");
            scelta = Int32.Parse(Console.ReadLine());
            if (scelta == 0)
            {
                worker.Titolo = TitoloDiStudio.LicenzaElementare;
            }
            else if (scelta == 1)
            {
                worker.Titolo = TitoloDiStudio.LicenzaMedia;
            }
            else if (scelta == 2)
            {
                worker.Titolo = TitoloDiStudio.DiplomaSuperiore;
            }
            else if (scelta == 3)
            {
                worker.Titolo = TitoloDiStudio.Laurea;
            }
            else if (scelta == 4)
            {
                worker.Titolo = TitoloDiStudio.Dottorato;
            }
            Console.WriteLine("Data di nascita: ");
            worker.DataDiNascita = InserisciData();
            Console.WriteLine("Data di assunzione: ");
            worker.DataAssunzione = InserisciData();
            Console.WriteLine("Mensilità: ");
            worker.Mensilità = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Stipendio Mensile: ");
            worker.StipendioMensile = Int32.Parse(Console.ReadLine());

           

            return worker;
        }
        public override string ToString()
        {
            return string.Format("Nome: {0} \n Cognome: {1} \n Genere: {2} \n Età: {3} \n Data di Nascita: {4:d} \n " +
                "Anni di servizio: {5} \n Data assunzione: {6} \n Stipendio Mensile: {7} \n Mensilità: {8} \n ",
                Nome, Cognome, Sesso, Età, DataDiNascita, AnniServizio, DataAssunzione, StipendioMensile, Mensilità);
        }
    }
}
