using System.Collections.Generic;


namespace GenerateLine
{
    class Request
    {
        public List<char> symbolMask;

        public List<int> countBySymbolMask;
        
        public Request()
        {
            symbolMask = new List<char>();
            countBySymbolMask = new List<int>();
        }

        public void AddChild(char command, int repeats)
        {
            symbolMask.Add(command);
            countBySymbolMask.Add(repeats);
        }
    }
}
