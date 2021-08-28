﻿using System;
using System.Collections.Generic;

namespace GenerateLine
{
    class Program
    {
        static void Main(string[] args)
        {

            string mask1 = "X3U3D3";
            string mask2 = "X3{ - }U3{ - }D3";
            string mask3 = "{+7 (}X3{) }X3{-}X2{-}X2";
            string mask4 = "{Биrrrrrлет No }?7{-}Z";
            int repeatsMask = 3;

            var listString = new List<string>() { mask1, mask2, mask3, mask4 };

            var generator = new Generator();

            foreach (var v in listString)
            {
                var command = generator.GetCommand(v);
                if (command == null)
                {
                    Console.WriteLine("Команда не распознана");
                }
                else
                {

                    command.Execute(repeatsMask);
                    Console.WriteLine("Маска: {0}", v);

                    Console.WriteLine("Результат маски:\n{0}", generator);
                    Console.WriteLine("\n");
                }
            }
        }

    }
}
