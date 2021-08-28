using System;
using System.Collections.Generic;
using System.Linq;

namespace GenerateLine
{
    class ParserInput : ICommandInput
    {
        private Router _router;

        private List<char> maskCommand = new List<char> { 'X', 'C', 'U', 'D', 'Z', '?' };

        private List<char> constBrackets = new List<char> { '{', '}' };

        public Router Router { get => _router; set => _router = value; }
        public List<char> MaskCommand { get => maskCommand; set => maskCommand = value; }
        public List<char> ConstBrackets { get => constBrackets; set => constBrackets = value; }

        public ParserInput(Router router)
        {
            Router = router;
        }

        public ICommand GetCommand()
        {
            var rawCommand = Console.ReadLine().ToList();
            Request request = ParseString(rawCommand);
            return Router.CreateCommand(request);
        }

        public ICommand GetCommand(string raw)
        {
            var rawCommand = raw.ToList();
            Request request = ParseString(rawCommand);
            return Router.CreateCommand(request);
        }

        private Request ParseString(List<char> input)
        {
            Request req = new Request();
            int i = 0;
            while (!(i > input.Count))
            {
                try
                {
                    if (input[i].Equals(ConstBrackets[0]))
                    {
                        int prevIndex = i;

                        while (!input[i].Equals(ConstBrackets[1]))
                        {

                            req.AddChild(input[i], 1);

                            i++;
                        }

                        req.AddChild(input[i], 1);
                    }
                    else if (CheckValidWord(input[i]))
                    {
                        int resultNum = GetNumbers(input, i + 1);

                        req.AddChild(input[i], resultNum);
                    }
                    else if (!IsDigit(input[i]))
                    {
                        req.AddChild(input[i], 1);
                    }
                    i++;
                }
                catch (Exception)
                {

                    break;
                }
            }
            return req;
        }
        
        private bool CheckValidWord(char word)
        {
            if (MaskCommand.Contains(word))
            {
                return true;
            }
            return false;
        }

        private int GetNumbers(List<char> other, int nu)
        {
            string number = "";
            try
            {
                for (int i = nu; i < other.Count; i++)
                {
                    if (IsDigit(other[i]))

                    {

                        number += other[i];

                    }

                    else if (String.IsNullOrWhiteSpace(number))

                    {
                        return 1;
                    }
                    else
                    {

                        return Convert.ToInt32(number);
                    }
                }
            }
            catch (Exception)
            {
                return 1;
            }
            return !String.IsNullOrWhiteSpace(number) ? Convert.ToInt32(number) : 1;
        }

        private static bool IsDigit(char ch)
        {
            return char.IsDigit(ch);
        }
    }
}

