using System;
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
            string mask4 = "{Билет No }?7{-}Z";
            int repeatsMask = 3;

            var listString = new List<string>() { mask1, mask2, mask3, mask4 };

            var generator = new Generator();
        }

    }
}
