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

            string path = "";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = "";
            string fullpath = Path.Combine(path, filename);
            if(File.Exists(fullpath))
            {
                File.Create(fullpath);
            }
            int quantita = 0;
            Console.WriteLine("Inserisci il numero di lavoratori che vuoi inserire: ");
            quantita = Int32.Parse(Console.ReadLine());
            
        }
    }
}
