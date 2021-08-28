using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate
{
    public class Journal
    {
        private List<string> entries;


        public Journal()
        {
            entries = new List<string>();
        }


        /// <summary>
        /// добавить значение
        /// </summary>
        /// <param name="text">строка</param>
        public void AddEntry(string text)
        {
            entries.Add(text);
        }


        /// <summary>
        /// удалить значение из приватного поля
        /// </summary>
        /// <param name="index">индекс, который нужно удалить</param>
        public void RemoveEntry(int index)
        {
            if (index < entries.Count && index >= 0)
                entries.RemoveAt(index);
        }


        /// <summary>
        /// Форматированный вывод в консоль
        /// </summary>
        /// <returns>строка</returns>
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }


        /// <summary>
        /// Получение маски
        /// </summary>
        /// <returns>строка</returns>
        public string GetMask() 
        {
            return entries.ElementAt(0);
        }

        /// <summary>
        /// Получение строк
        /// </summary>
        /// <returns>массив строк</returns>
        public List<string> GetStringData() 
        {
            return entries.GetRange(1, entries.Count);
        }


        /// <summary>
        /// Сравнение журналов
        /// </summary>
        /// <returns>булевое значение</returns>
        public static bool operator ==(Journal j1, Journal j2)
        {
            if(j1.GetMask() == j2.GetMask())
            {
                return true;
            }
            return false;
        }
        

        /// <summary>
        /// Обратно сравнение журналов
        /// </summary>
        /// <returns>булевое значение</returns>
        public static bool operator !=(Journal j1, Journal j2)
        {
            if (j1.GetMask() != j2.GetMask())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Перезагрузка метода, чтобы складывать наши списки
        /// </summary>
        /// <param name="j1"></param>
        /// <param name="j2"></param>
        /// <returns>новый журнал</returns>
        public static Journal operator +(Journal j1, Journal j2)
        {

            return Journal.ConcateEntries(j1, j2);

           
        }

        /// <summary>
        /// Получение приавтного поля
        /// </summary>
        /// <returns>массив строка</returns>
        public List<string> GetEnries()
        {
            return entries;
        }

        /// <summary>
        /// Публичный метод для записи
        /// </summary>
        /// <returns></returns>
        public string Print()
        {

            entries.RemoveAt(0);
            return "\n" + ToString();
        }

        /// <summary>
        /// Соединяем два журнала в один
        /// </summary>
        /// <param name="j1">первый журнал</param>
        /// <param name="j2">второй журнал</param>
        /// <returns>сформированный журнал</returns>
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

    // handles the responsibility of persisting objects
    public class PersistenceManager
    {

        /// <summary>
        /// Сохраняет файл
        /// </summary>
        /// <param name="journal">журнал</param>
        /// <param name="filename">полный путь до файла</param>
        /// <param name="overwrite">перезаписывать ли файл</param>
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (Path.GetDirectoryName(filename) == null || String.IsNullOrWhiteSpace(Path.GetDirectoryName(filename)))
            {
                throw new Exception("Похоже такого файла нет.");
            }

            File.WriteAllText(filename, journal.ToString());
        }


        /// <summary>
        /// Формируют журнал записей из файла
        /// </summary>
        /// <param name="filename">полный путь до файла</param>
        /// <returns>записанные журнал</returns>
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

        /// <summary>
        /// Удаляет файл
        /// </summary>
        /// <param name="filename"></param>
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
