using System;
using System.Text;

namespace GenerateLine.Commands
{

    class GenerateSymbol : ICommand
    {

        private int _repeat;

        private char _ch;

        private GenerateStore _store;

        static Random rnd = new Random();

        private readonly string _set;

        public GenerateSymbol() { }

        public GenerateSymbol(string set)
        {
            _set = set;
        }

        public GenerateSymbol(int repeat, GenerateStore store, string set) : this(set)
        {
            _repeat = repeat;
            _store = store;
        }

        public GenerateSymbol(char ch, GenerateStore store)
        {
            _ch = ch;
            _store = store;
        }


        public virtual void Execute()
        {
            StringBuilder sb = new StringBuilder(_repeat);
            for (int i = 0; i < _repeat; i++)
                sb.Append(_set[rnd.Next(_set.Length)]);
            _store.AddContent(sb.ToString());
        }

        public void Execute(int co)
        {
            throw new NotImplementedException();
        }
    }
}
