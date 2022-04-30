using entering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Вікторина;

namespace дз {
    class Program2 {
        public static string reverse(string s) {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        public static string Way(string way, int i1 = 4) {
            way = reverse(way);
            StringBuilder el = new StringBuilder();
            for (int i = i1; i < way.Length; i++) {
                if (way[i] == '\\') {
                    way = el.ToString();
                    way = reverse(way); return way;
                }
                el.Append(way[i]);
            }
            way = el.ToString();
            way.Reverse();
            return way;
        }
        public static string way;




        public static void NotMain() {
            List<string> questions = new List<string>() { "Питання", "Гравці","","Назад" };
            int y = Entering.Choose(questions, 0, 2);
            if (y == questions.Count - 1) return;
            if ( y== 0) {
                Console.Clear();
                string gt = "";
                int p = 0;
                bool da = false;
                IntroductoryText();
                ChooseDirictory.dir();
                int q = 1;
                if (p != -1) {
                    q = 2;
                }
                if (q == 2) EditFile.edit(gt);

                CreatingFile.create(da, gt); Console.Clear();
            }
            else {
                Console.Clear();
                Users.EditUsers();
                return;
            }
        }


        private static void IntroductoryText() {
            Console.SetCursorPosition(22, 9);
            Console.Write("Щоб створити новий розділ/підрозділ натисніть Tab");
            Console.SetCursorPosition(26, 12);
            Console.Write("Щоб створити питання натисніть пробіл");
            Console.SetCursorPosition(32, 15);
            Console.Write("Backspace - крок назад");
            Console.SetCursorPosition(28, 18);
            Console.Write("'r' або 'к' - переназвати розділ");
            Console.SetCursorPosition(28, 20);
            Console.Write("Правильну відповідь позначати '^'");
            Console.SetCursorPosition(0, 0);
        }
    }
}