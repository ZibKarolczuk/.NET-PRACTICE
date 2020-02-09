using System;
using System.Collections.Generic;

namespace ListManipulatingData
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<string> list = new List<string>();
            var list = new List<string>();

            list.Add("Hello");
            list.Add("beautiful");
            list.Add("World");
            list.Add("from");
            list.Add("Zibi");
            list.Add("or");
            list.Add("odeon");

            //ENUMARATING DATA
            for (var i = 0; i < list.Count; i++)
            {
                System.Console.WriteLine(list[i].ToLower());
            }

            System.Console.WriteLine("..");

            //ENUMARATING DATA BACKWARDS
            for (var i = list.Count - 1; i >= 0; i--)
            {
                System.Console.WriteLine(list[i].ToUpper());
            }

            System.Console.WriteLine("..");

            //REMOVING ITEM FROM LIST MUST BE PERFORMED BACKWARDS!!!
            //INSERTING ITEM IS ALSO BETTER TO PERFORMED BACKWARDS!!!
            // for (var i = list.Count - 1; i >= 0; i--)
            // {
            //     if (list[i].Contains("o")) list.RemoveAt(i);
            // }

            //OR SUPLIER BY REMOVEALL()
            list.RemoveAll(x => x.Contains("o"));

            for (var i = 0; i < list.Count; i++)
            {
                System.Console.WriteLine(list[i].ToLowerInvariant());
            }
        }
    }
}
