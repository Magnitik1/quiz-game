using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;
using дз;

namespace Вікторина2 {
    class Program {
        static MainMenu mainMenu = new MainMenu();
        public static string way= @"Вікторина2\Users";
        public static string way5= Program2.way = @"Вікторина2\questions";
        public static void Main(string[] args) {
            registration.Login = null;
            Game.first = true;
            Console.CursorVisible = false;
            Game.randquestions.Clear();
            Console.WindowWidth = 110;
            Console.WindowHeight = 25;
            Console.WindowLeft = 0;
            Console.WindowTop = 5;
            Console.CursorVisible = false;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            mainMenu.run();
        }
    }
}
