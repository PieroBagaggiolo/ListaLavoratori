using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLavoratori
{
    [Serializable]
    public enum Genere
    {
        M,
        F,
        G
    }
    public enum TitoloDiStudio
    {
        LicenzaElementare = 0,
        LicenzaMedia = 1,
        DiplomaSuperiore = 2,
        Laurea = 3,
        Dottorato = 4
    }
    public enum Tipologia
    {
        Autonomo,
        Dipendente
    }
    public class Lavoratori
    {
        public Guid IDWorker { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Genere Sesso{ get; set; }
        public TitoloDiStudio Titolo{get; set;}
        public DateTime DataDiNascita { get; set; }
        public DateTime DataAssunzione { get; set; }
        public int Età { get; set; }
        public int AnniServizio { get; set; }
        public double StipendioMensile { get; set; }
        public int Mensilità { get; set; }
        public Tipologia Tipo {get; set;}
        public double RAL { get; set; }
        public double Tasse { get; set; }
        public Lavoratori(){ }

        public virtual int CalcolaAnni(DateTime start)
        {
            return DateTime.Now.Year - start.Year;
        }
        public Lavoratori(string nome, string cognome, DateTime nascita, Genere genere, TitoloDiStudio titolo, DateTime assunzione, 
            double stipMensile, int mensilità)
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
            Tasse = CalcolaTasse();
        }

        public Lavoratori(string nome, string cognome, DateTime nascita, Genere genere, TitoloDiStudio titolo, DateTime assunzione,
            double stipMensile, int mensilità, Guid id)
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
            Tasse = CalcolaTasse();
            IDWorker = id;
        }
        public DateTime InserisciData()
        {
            Console.WriteLine("Giorno");
            int gg = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Mese");
            int mm = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Anno");
            int aa = Int32.Parse(Console.ReadLine());

            DateTime data = new DateTime(aa, mm, gg);
            return data;
        }
        public Lavoratori InsertWorker(Lavoratori worker)
        {
            Console.WriteLine("Inseriscine i dati:");
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
            if(worker.Mensilità <= 12)
            {
                worker.Tipo = Tipologia.Autonomo;
            }
            else if(worker.Mensilità>12)
            {
                worker.Tipo = Tipologia.Dipendente;
            }
            Console.WriteLine("Stipendio Mensile: ");
            worker.StipendioMensile = Int32.Parse(Console.ReadLine());


            worker.Età = CalcolaAnni(worker.DataDiNascita);
            worker.AnniServizio = CalcolaAnni(worker.DataAssunzione);
            worker.RAL = worker.StipendioMensile * worker.Mensilità;
            
            return worker;
        }
        public override string ToString()
        {
            return string.Format("Nome: {0} \nCognome: {1} \nGenere: {2} \nEtà: {3} \nData di Nascita: {4:d} \n" +
                "Anni di servizio: {5} \nData assunzione: {6} \nStipendio Mensile: {7} \nMensilità: {8} \nTipo di lavoratore1: {9}" +
                "\nRAL: {10} \nTasse: {11}",
                Nome, Cognome, Sesso, Età, DataDiNascita, AnniServizio, DataAssunzione, StipendioMensile, Mensilità, Tipo, RAL, Tasse);
        }
        
        public double CalcolaTasse()
        {
            double tasse = 0;
            if (Tipo == Tipologia.Dipendente)
            {
                
                if (0 < RAL || RAL < 6000)
                {
                    tasse = 0;
                }
                else if (6000 < RAL || RAL < 15000)
                {
                    tasse = RAL / (100 * 15);
                }
                else if (15000 < RAL || RAL < 25000)
                {
                    tasse = RAL / (100 * 30);
                }
                else if (25000 <  RAL ||  RAL <= 35000)
                {
                    tasse =  RAL / (100 * 40);
                }
                else if ( RAL > 35000)
                {
                    tasse =  RAL / (100 * 50);
                }
            }
            else if ( Tipo == Tipologia.Autonomo)
            {
                if (RAL < 50000)
                {
                    tasse =  RAL / (100 * 15);
                }
                else if (RAL >= 500000)
                {
                    tasse =  RAL / (100 * 30);
                }
            }

            return tasse;
        }
        public int GetMensilità()
        {
            return Tipo == Tipologia.Autonomo ? 12 : 13;
        }
    }
}
