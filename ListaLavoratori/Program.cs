using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ListaLavoratori
{
    class Program
    {
        private static object listSerializer;

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
                var lav = lavoratore.InsertWorker(lavoratore);
                listL.Add(lavoratore);
            }
            StringBuilder sl = new StringBuilder();
            foreach (var p in listL)
            {
                sl.AppendLine(p.ToString());
            }
            File.WriteAllText(fullpath, sl.ToString());

            string result = File.ReadAllText(fullpath);

            Console.WriteLine(result);


            string file2 = "test2.xml";
            fullpath = Path.Combine(path, file2);


            XmlSerializer lista = new XmlSerializer(typeof(List<Lavoratori>));
            using (FileStream fs = File.Open(fullpath, FileMode.OpenOrCreate))
            {
                lista.Serialize(fs, listL);
            }


        }
    }
}
