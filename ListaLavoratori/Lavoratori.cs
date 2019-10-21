using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLavoratori
{
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
        public Lavoratori()
        {

        }
        public virtual int CalcolaAnni(DateTime start)
        {
            return DateTime.Now.Year - start.Year;
        }
        public Lavoratori(string nome, string cognome, DateTime nascita, Genere genere, TitoloDiStudio titolo, DateTime assunzione, int stipMensile, int mensilità)
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
        }
    }
}
