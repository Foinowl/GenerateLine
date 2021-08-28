using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateLine
{
    public class Journal
    {
        private List<string> entries;
        public Journal()
        {
            entries = new List<string>();
        }

        public void AddEntry(string text)
        {
            entries.Add(text);
        }

        public void RemoveEntry(int index)
        {
            if (index < entries.Count && index >= 0)
                entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }


        public string GetMask() 
        {
            return entries.ElementAt(0);
        }


        public List<string> GetStringData() 
        {
            return entries.GetRange(1, entries.Count);
        }

        public static bool operator ==(Journal j1, Journal j2)
        {
            if(j1.GetMask() == j2.GetMask())
            {
                return true;
            }
            return false;
        }
        
        public static bool operator !=(Journal j1, Journal j2)
        {
            if (j1.GetMask() != j2.GetMask())
            {
                return false;
            }
            return true;
        }

        public static Journal operator +(Journal j1, Journal j2)
        {

            return Journal.ConcateEntries(j1, j2);

           
        }

        public List<string> GetEnries()
        {
            return entries;
        }

        public string Print()
        {

            entries.RemoveAt(0);
            return "\n" + ToString();
        }

        private static Journal ConcateEntries(Journal j1, Journal j2)
        {
            var res = j1.entries.Union(j2.entries);
            Journal journal = new Journal();
            foreach (var st in res)
            {
                journal.AddEntry(st);
            }
            return journal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }

    public class PersistenceManager
    {

        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (Path.GetDirectoryName(filename) == null || String.IsNullOrWhiteSpace(Path.GetDirectoryName(filename)))
            {
                throw new Exception("Похоже такого файла нет.");
            }

            File.WriteAllText(filename, journal.ToString());
        }

        public Journal LoadFile(string filename)
        {
            Journal journal = new Journal();
            try
            {

                using (StreamReader sr = new StreamReader(filename, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        journal.AddEntry(line);
                    }
                }
            }catch(Exception)
            {
                throw new Exception("Похоже такого файла нет.");
            }

            return journal;
        }

        public void DeleteFile(string filename)
        {
            if (Path.GetDirectoryName(filename) == null || String.IsNullOrWhiteSpace(Path.GetDirectoryName(filename)))
            {
                throw new Exception("Похоже такого файла нет.");
            }
            try
            {
                File.Delete(filename);
            }catch(Exception)
            {
                throw new Exception("Произошла ошибка. Посмотри на корректность входящей последовательности файла. Ахх,да, есть варик, что файла нет :)");
            }

        }
    }
}
