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

        public Generator()
        {
            store = new GenerateStore();
            input = new ParserInput(new Router(store));
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

        public override string ToString()

        {
            return store.Print();
        }
    }
}

