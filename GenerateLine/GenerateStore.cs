using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateLine
{
    class GenerateStore
    {
        private List<string> _patterns = new List<string>();

        private StringBuilder stringBuilder = new StringBuilder("");

        public GenerateStore()
        {
        }

        public void AddLinePattern()
        {
            _patterns.Add(WriteLine());
            ResetLine();
        }

        public void AddContent(string st)
        {
            stringBuilder.Append(st);
        }

        public void ResetLine()
        {
            stringBuilder.Remove(0, stringBuilder.Length);
        }
        public void ResetPatterns()
        {
            _patterns = new List<string>();
        }

        private string WriteLine()
        {
            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            string output = string.Join(Environment.NewLine, _patterns.ToArray());

            return output;
        }

        public List<string> GetData()
        {
            return _patterns;
        }
        public string Print()
        {
            return ToString();
        }
    }
}
