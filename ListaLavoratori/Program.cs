using System;
using System.Collections.Generic;
using System.Data;
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
            string filename = "SaveTesto.txt";
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
            //scrittura su file di testo
            StringBuilder sl = new StringBuilder();
            foreach (var p in listL)
            {
                sl.AppendLine(p.ToString());
            }
            File.WriteAllText(fullpath, sl.ToString());

            string result = File.ReadAllText(fullpath);

            Console.WriteLine(result);

            //scrittura su file XML
            XmlSerializer lista = new XmlSerializer(typeof(List<Lavoratori>));
            fullpath = Path.Combine(path, "Test.xml");

            using (FileStream fs = File.Open(fullpath, FileMode.OpenOrCreate))
            {
                lista.Serialize(fs, listL);
            }

            //scrittura su DB
            DataSet ds = DBHelp.GetWorker();

        }

        private static void PrintDataSet(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
            }
        }
    }
}
