using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLavoratori
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lavoratori> listL = new List<Lavoratori>();

            string path = @"C:\Users\CORSO 44\Documents\GitHub\ListaLavoratori\ListaLavoratori\ListaLavoratori\Elementi";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = "test1.txt";
            string fullpath = Path.Combine(path, filename);
            if(File.Exists(fullpath))
            {
                File.Create(fullpath);
            }
            int quantita = 0;
            do
            {
                //try
                //{
                    Console.WriteLine("Inserisci il numero di lavoratori che vuoi inserire: ");
                    quantita = Int32.Parse(Console.ReadLine());
                //}
                //catch(Exception ex)
                //{
                //    Console.WriteLine("Riscontrata eccezzione", ex);
                //}

                
                
            }
            while (quantita == 0);
            for(int i = 0; i<quantita; i++)
            {
                Lavoratori lavoratore = new Lavoratori();
                lavoratore.InsertWorker(lavoratore);
                listL.Add(lavoratore);
            }

            foreach(var w in listL)
            {
                
            }
            
            
        }
    }
}
