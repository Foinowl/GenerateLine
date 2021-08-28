using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateLine
{
    class Generator
    {
        public GenerateStore store;

        public ParserInput input;

        private PersistenceManager managerFiles;

        public Generator()
        {
            store = new GenerateStore();
            input = new ParserInput(new Router(store));
            managerFiles = new PersistenceManager();
        }

        public ICommand GetCommand(string v)
        {
            store.ResetPatterns();
            return input.GetCommand(v);
        }

        public ICommand GetCommand()
        {
            store.ResetPatterns();
            return input.GetCommand();
        }

        public void WriteFile(string filename, string mask, int rep = 1)
        {

            Journal journal = GetDataJournal(mask, rep);

            managerFiles.SaveToFile(journal, filename);
        }

        public void WriteFile(string filename, string mask, int rep = 1, bool overwrite = false)
        {
            if (!overwrite)
            {
                WriteFile(filename, mask, rep);
                return;
            }

            Journal journal = GetDataJournal(mask, rep); ;

            Journal prevJournal = managerFiles.LoadFile(filename);

            if (journal == prevJournal)
            {
                Journal j = journal + prevJournal;
                managerFiles.SaveToFile(j, filename, overwrite);
            }
            else
            {
                throw new Exception("Маска должна быть в начале строки!");
            }
        }

        public void DeleteFile(string filename)
        {
            managerFiles.DeleteFile(filename);
        }

        private Journal GetDataJournal(string mask, int rep)
        {
            var command = GetCommand(mask);
            command.Execute(rep);

            var data = store.GetData();

            Journal journal = new Journal();
            journal.AddEntry(mask);
            foreach (string str in data)
            {
                journal.AddEntry(str);
            }

            return journal;
        }

        public List<string> GetFile(string filename)
        {
            var j = managerFiles.LoadFile(filename);
            return j.GetEnries();
        }

        public string GetMaskFromFile(string filename)
        {
            var j = managerFiles.LoadFile(filename);
            return j.GetMask();
        }

        public List<string> GetDataFromFile(string filename)
        {
            var j = managerFiles.LoadFile(filename);
            return j.GetStringData();
        }

        public override string ToString()

        {
            return store.Print();
        }
    }
}

