using System;
using System.Text;
using Generate.Commands;

namespace Generate
{

    /// <summary>
    /// Генериует констатныпе символы: { }
    /// </summary>
    class GenerateConstant : GenerateSymbol
    {
        private char _ch;
        private GenerateStore _store;
        public GenerateConstant() { }

        public GenerateConstant(char ch, GenerateStore store) : base(ch, store)
        {
            _ch = ch;
            _store = store;
        }

        public override void Execute()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_ch);
            _store.AddContent(sb.ToString());
        }

        public void Execute(int co)
        {
            throw new NotImplementedException();
        }
    }
}
