using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Вікторина2;

namespace entering {
    public class Entering {
        static ConsoleKeyInfo cki;
        public static int Choose(List<string> arr, int pass = 0, int skip=42) {
            int num = arr.Count;
            int q = pass;
            bool el = true;
            if (Console.CursorVisible) { el = Console.CursorVisible = false; }
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(arr[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 1; i < num; i++) { Console.WriteLine(" " + arr[i]); }
            do {
                cki = Console.ReadKey(true);
                Console.SetCursorPosition(1, q); Console.WriteLine(arr[q - pass]);
                if (cki.Key == ConsoleKey.DownArrow) { q++; if (q == skip) q++;if (q >= num + pass) { q = pass;  } }
                if (cki.Key == ConsoleKey.UpArrow) { q--; if (q == skip) q--;if (q < pass) { q = num - 1 + pass;  } }
                if (cki.Key == ConsoleKey.Delete)return -4-q;
                if (cki.Key == ConsoleKey.Tab) return -1;
                if (cki.Key == ConsoleKey.Spacebar) return -2;
                if (cki.Key == ConsoleKey.Backspace) return -3;
                if (cki.Key == ConsoleKey.R) return -10-q;
                if (cki.Key == ConsoleKey.Escape) { Console.Clear(); Program.Main(null); System.Environment.Exit(0); }
                Console.SetCursorPosition(1, q);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(arr[q - pass]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            } while (cki.Key != ConsoleKey.Enter);
            if (el) Console.CursorVisible = true;
            return q;
        }
        public static int Choose(string[] arr, int pass = 0, int skip = 42) {
            List<string> lst = new List<string>() { arr[0] };
            for (int i = 1; i < arr.Length; i++) {
                lst.Add(arr[i]);
            }
            return Choose(lst,pass,skip);
        }
    }
}
