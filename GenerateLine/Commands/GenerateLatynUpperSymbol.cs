using System;
using Generate.Commands;

namespace Generate
{
    /// <summary>
    /// Генерирует Латинские большие: U
    /// </summary>
    class GenerateLatynUpperSymbol : GenerateSymbol
    {
        private int _repeat;
        private GenerateStore _store;
        static Random rnd = new Random();

        private static readonly string numericSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public GenerateLatynUpperSymbol(int repeat, GenerateStore store) : base(repeat, store, numericSet)
        {
            _repeat = repeat;
            _store = store;
        }

        public override void Execute()
        {
            base.Execute();
        }

        public void Execute(int co)
        {
            throw new NotImplementedException();
        }
    }
}
