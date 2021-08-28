using System;
using GenerateLine.Commands;

namespace GenerateLine
{

    class GenerateLatynLowerSymbol : GenerateSymbol
    {
        private int _repeat;
        private GenerateStore _store;
        static Random rnd = new Random();

        private static readonly string numericSet = "abcdefghijklmnopqrstuvwxyz";
        public GenerateLatynLowerSymbol(int repeat, GenerateStore store) : base(repeat, store, numericSet)
        {
            _repeat = repeat;
            _store = store;
        }

        public override void  Execute()
        {
            base.Execute();
        }

        public void Execute(int co)
        {
            throw new NotImplementedException();
        }
    }
}
