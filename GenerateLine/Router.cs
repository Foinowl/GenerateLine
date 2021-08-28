using System.Collections.Generic;


namespace GenerateLine
{
    class Router
    {
        private GenerateStore _store;
        public Router(GenerateStore store)
        {
            _store = store;
        }

        public ICommand CreateCommand(Request request)
        {
            int i = 0;

            List<ICommand> obj = new List<ICommand>();
            ICommand ob = null;
            while (i < request.symbolMask.Count)
            {
                if ('X'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateNumericSymbol(request.countBySymbolMask[i], _store);
                }
                else if ('C'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateLatynAnySymbol(request.countBySymbolMask[i], _store);
                }
                else if ('U'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateLatynUpperSymbol(request.countBySymbolMask[i], _store);
                }
                else if ('D'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateLatynLowerSymbol(request.countBySymbolMask[i], _store);
                }
                else if ('Z'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateSignSymbol(request.countBySymbolMask[i], _store);
                }
                else if ('?'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateAnyLatinAndNumberSymbol(request.countBySymbolMask[i],
                    _store);
                }
                else if ('{'.Equals(request.symbolMask[i]))
                {
                    i++;

                    while (!request.symbolMask[i].Equals('}'))

                    {
                        ob = new GenerateConstant(request.symbolMask[i], _store);
                        i++;
                        obj.Add(ob);

                    }
                    i++;
                    continue;

                }
                else if (!'}'.Equals(request.symbolMask[i]))
                {
                    ob = new GenerateConstant(request.symbolMask[i], _store);
                }
                i++;
                obj.Add(ob);
            }
            return new DefaultState(this, obj);
        }

        class DefaultState : ICommand
        {
            protected readonly Router Router;

            private List<ICommand> Lists;
                public DefaultState(Router router, List<ICommand> list)
                {
                    Router = router;
                    Lists = list;
                }

            public void Execute()
            {
                foreach (var v in Lists)
                {
                    v.Execute();
                }
                Router._store.AddLinePattern();
            }

            public void Execute(int co)
                {
                    for (int i = 0; i < co; i++)
                    {
                        Execute();
                    }
                }
            }
    }
}
