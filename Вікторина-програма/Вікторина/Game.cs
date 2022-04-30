using entering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дз;

namespace Вікторина2 {
    public class Game {
        public static List<string> randquestions = new List<string>();
        public static int cansw = 0;
        public static string way = Program2.way;
        public static Random rnd = new Random();
        public static string gt = "";
        public static bool randquest = false;
        public static bool first;

        public static void ChooseGame() {
            Program2.way = Program.way5;
            List<string> questions = new List<string>();
            bool Math = false;
            bool Color = false;
            while (Directory.GetDirectories(Program2.way).Length > 0) {
                string[] w = Directory.GetDirectories(Program2.way);
                foreach (var t in w) questions.Add(Way.GetNameOfWay(t, 0));
                if (first) { questions.Add("випадкові"); first = false; }
                int a;
                do {
                    Console.Clear();
                    a = Entering.Choose(questions);
                } while (a < 0);
                gt = questions[a];
                registration.gt = gt;
                Program2.way = Program2.way + "\\" + gt;
                questions.Clear();
                if (gt == "випадкові") { randquest = true; break; }
                if (gt == "математика") { Math = true; break; }
                if (gt == "кольори") { Color = true; break; }
            }

            if (Math) StartMath();
            else if (Color) StartColor();
            else { StartGame(); }


        }
        private static void StartColor() {
            first = true;
            string t = "";
            int count = Directory.GetFiles(Program2.way).Length;
            List<string> str = new List<string>();
            Random random = new Random();
            for (int i = 0; i < count - 1; i++) {
                string c = (random.Next(1, count)).ToString();
                if (str.Contains(c)) { i--; continue; }
                str.Add(c);

            }
            for (int i = 0; i < count - 1; i++) {
                Console.Clear();
                StreamReader sr = new StreamReader(Program2.way + '\\' + str[i] + ".txt");
                string u = sr.ReadLine();
                Console.WriteLine(u);
                string s = Console.ReadLine();
                s = s.ToLower();
                string h1 = sr.ReadLine();
                string h = sr.ReadLine();
                t = t + u + "\n" + s + "\n" + h1 + "/" + h + "\n\n";
                Console.SetCursorPosition(0, 1);
                if (s == h1 || s == h) {
                    cansw++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(s);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(s);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(h);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey(true);
                Console.Clear();

            }
            Console.WriteLine(cansw + " / " + (count - 1));
            if (registration.Login != null) {
                if (!Directory.Exists(Program.way + '\\' + registration.Login + '\\' + gt)) {
                    Directory.CreateDirectory(Program.way + '\\' + registration.Login + '\\' + gt);
                }
                while (true) {
                    string oo = Program.way + '\\' + registration.Login + '\\' + gt + '\\' + gt + i + ".txt";
                    if (first)
                        if (File.Exists(oo)) {
                            i++;
                            continue;
                        }
                        else File.Create(oo).Close();
                    StreamWriter sw = new StreamWriter(oo, true);
                    sw.WriteLine(t);
                    sw.Write("\n" + cansw + " / " + (count - 1));
                    sw.Close();
                    sw = new StreamWriter(Program.way + '\\' + registration.Login + "\\UserAnswers.txt");
                    sw.WriteLine(gt + " - " + cansw);
                    sw.Close();
                    break;
                }
            }
            Console.ReadKey(true);
            Console.Clear();
            NewGameMenu(true);
        }


        private static void StartMath() {
            first = true;
            cansw = 0;
            string t = "";
            Console.Clear();
            int a3 = rnd.Next(0, 100);
            int a1 = rnd.Next(0, 200);
            int a2 = rnd.Next(0, 100);
            Console.WriteLine(a1 + "+" + a2 + "+" + a3 + "=?");
            string s = Console.ReadLine();
            t = a1 + "+" + a2 + "+" + a3 + "=?\n" + s + "\n" + (a1 + a2 + a3) + '\n';
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(a1 + a2 + a3);
            Console.ForegroundColor = ConsoleColor.White;
            if (s == (a1 + a2 + a3).ToString()) { cansw++; }
            a3 = rnd.Next(-911, 12452);
            a1 = rnd.Next(911, 12452);
            a2 = rnd.Next(-911, 12452);
            Console.WriteLine(a1 + "+" + a2 + "-" + a3 + "=?");
            s = Console.ReadLine();
            t = "\n" + t + a1 + "+" + a2 + "-" + a3 + "=?\n" + s + "\n" + (a1 + a2 - a3) + "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(a1 + a2 - a3);
            Console.ForegroundColor = ConsoleColor.White;
            if (s == (a1 + a2 - a3).ToString()) { cansw++; }
            a2 = rnd.Next(-911, 12452);
            a1 = rnd.Next(911, 12452);
            a3 = rnd.Next(-911, 12452);
            Console.WriteLine(a1 + "+" + a2 + "-" + a3 + "=?");
            s = Console.ReadLine();
            t = "\n" + t + a1 + "+" + a2 + "-" + a3 + "=?\n" + s + "\n" + (a1 + a2 - a3) + '\n';
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(a1 + a2 - a3);
            Console.ForegroundColor = ConsoleColor.White;
            if (s == (a1 + a2 - a3).ToString()) { cansw++; }

            a1 = rnd.Next(11, 20);
            a2 = rnd.Next(-2, 12);
            while (a2 == 0 || a2 == 1) {
                a2 = rnd.Next(-2, 12);
            }
            a3 = rnd.Next(-911, 12452);
            Console.WriteLine(a1 + "*" + a2 + "-" + a3 + "=?");
            s = Console.ReadLine();
            t = "\n" + t + a1 + "*" + a2 + "-" + a3 + "=?\n" + s + "\n" + (a1 * a2 - a3) + '\n';

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(a1 * a2 - a3);
            Console.ForegroundColor = ConsoleColor.White;
            if (s == (a1 * a2 - a3).ToString()) { cansw++; }

            a1 = rnd.Next(11, 20);
            a2 = rnd.Next(-2, 12);
            while (a2 == 0 || a2 == 1) {
                a2 = rnd.Next(-2, 12);
            }
            a3 = rnd.Next(-12, 29);
            Console.WriteLine(a1 + "*" + a2 + "*" + a3 + "=?");
            s = Console.ReadLine();
            t = "\n" + t + a1 + "*" + a2 + "*" + a3 + "=?\n" + s + "\n" + (a1 * a2 * a3) + '\n';

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(a1 * a2 * a3);
            Console.ForegroundColor = ConsoleColor.White;
            if (s == (a1 * a2 * a3).ToString()) { cansw++; }
            Console.WriteLine(cansw + " / 5");
            if (registration.Login != null) {
                if (!Directory.Exists(Program.way + '\\' + registration.Login + '\\' + gt)) {
                    Directory.CreateDirectory(Program.way + '\\' + registration.Login + '\\' + gt);
                }
                while (true) {
                    string oo = Program.way + '\\' + registration.Login + '\\' + gt + '\\' + gt + i + ".txt";
                    if (first)
                        if (File.Exists(oo)) {
                            i++;
                            continue;
                        }
                        else File.Create(oo).Close();
                    StreamWriter sw = new StreamWriter(oo, true);
                    t = t.Trim();
                    sw.WriteLine(t);
                    sw.Write("\n" + gt + " " + cansw + " / 5");
                    sw.Close();
                    sw = new StreamWriter(Program.way + '\\' + registration.Login + "\\UserAnswers.txt");
                    sw.WriteLine(gt + " - " + cansw);
                    sw.Close();
                    break;
                }
            }
            cansw = 0;
            Console.ReadKey(true);
            Console.Clear();
            StreamWriter sw2 = new StreamWriter(Program.way + '\\' + registration.Login + "\\UserAnswers.txt");
            sw2.WriteLine(gt + " - " + cansw);
            sw2.Close();
            NewGameMenu(true);
        }

        public static void StartGame() {
            int count;
            i = 1;
            if (randquest) count = 21;
            else count = Directory.GetFiles(Program2.way).Length;
            List<int> ag = new List<int>();
            bool first = true;
            string dir = "";
            for (int i1 = 0; i1 < count - 1; i1++) {
                List<string> temp = new List<string>();
                string quest;
                List<int> rightansw = new List<int>();
                if (randquest) {
                    string c = "";
                    List<string> str = new List<string>();
                    str = RandQuestion();
                    quest = str[0];
                    int len = str.Count;
                    for (int i = 1; i < len; i++) {
                        if (str[i].Contains('^')) { rightansw.Add(i - 1); str[i] = str[i].Trim('^'); }
                        temp.Add(str[i]);
                    }
                }
                else {

                    int a = rnd.Next(1, count);
                    if (ag.Contains(a)) { i1--; continue; }
                    ag.Add(a);
                    StreamReader sr = new StreamReader(Program2.way + '\\' + a + ".txt");

                    Console.Clear();
                    quest = sr.ReadLine();

                    int o = 0;

                    while (true) {
                        string f = sr.ReadLine();
                        if (f == null) break;
                        if (f.Contains('^')) { rightansw.Add(o); f = f.Trim('^'); }
                        temp.Add(f); o++;
                    }
                }

                if (registration.Login != null) {
                    if (!Directory.Exists(Program.way + '\\' + registration.Login + '\\' + gt)) {
                        Directory.CreateDirectory(Program.way + '\\' + registration.Login + '\\' + gt);
                    }
                    if (first) while (true) {

                            if (!Directory.Exists(Program.way + '\\' + registration.Login + '\\' + gt)) {
                                Directory.CreateDirectory(Program.way + '\\' + registration.Login + '\\' + gt);

                            }
                            dir = Program.way + '\\' + registration.Login + '\\' + gt;
                            break;
                        }
                }
                ChoosingAnswers(temp, quest, rightansw, gt, first, dir);
                first = false;
            }
            Console.Clear();
            Console.WriteLine(cansw + " / " + (count - 1));
            if (registration.Login != null) {
                if (!File.Exists(Program.way + '\\' + registration.Login + "\\UserAnswers.txt")) { File.Create(Program.way + '\\' + registration.Login + "\\UserAnswers.txt").Close(); }
                StreamWriter sw = new StreamWriter(Program.way + '\\' + registration.Login + "\\UserAnswers.txt", true);
                sw.WriteLine(gt + " - " + cansw);
                sw.Close();
            }
            Console.ReadKey(true);
            cansw = 0;
            first = NewGameMenu(first);
        }

        public static bool NewGameMenu(bool first) {
            if (registration.Login == null) {

                Program.Main(null);
            }
            string[] s = { "Нова гра", "Меню гравця " + registration.Login, "Вийти в головне меню" };
            int y = 0;

            do {
                Console.Clear();
                y = Entering.Choose(s);
            } while (y < 0);
            if (y == 0) { first = true; ChooseGame(); }
            if (y == 1) { registration.AlreadyLogined(); }
            Console.Clear();
            registration.Login = null;
            return first;
        }

        private static List<string> RandQuestion() {
            List<string> file = new List<string>();
            string tempWay = Program.way5;
            while (true) {
                if (Directory.GetFiles(tempWay).Length < 1) {
                    string[] g = Directory.GetDirectories(tempWay);
                    tempWay = g[rnd.Next(0, g.Length - 1)];
                }
                else {
                    string jojo = tempWay + '\\' + rnd.Next(1, Directory.GetFiles(tempWay).Length + 1) + ".txt";
                    if (randquestions.Contains(jojo) || jojo.Contains("кольори")) {
                        tempWay = Program.way5;
                        continue;
                    }
                    randquestions.Add(jojo);
                    StreamReader sr = new StreamReader(jojo);
                    while (true) {
                        string pe = sr.ReadLine();
                        if (pe == null) break;
                        file.Add(pe);
                    }
                    sr.Close();
                    return file;
                }
            }

        }

        static int i = 1;
        private static void ChoosingAnswers(List<string> temp, string quest, List<int> rightansw, string gt, bool first, string dir) {
            List<int> choosen = new List<int>();
            for (int j = 0; j < rightansw.Count; j++) {
                Console.Clear();
                Console.WriteLine(quest);
                int y = Entering.Choose(temp, 1);
                if (y < 0) { j--; continue; }
                if (choosen.Contains(y)) {
                    j--;
                    temp[y - 1] = temp[y - 1].Substring(0, temp[y - 1].Length - 2);
                    choosen.RemoveAt(j);
                    if (rightansw[j] + 1 == y) {
                        cansw--;
                    }
                    j--;
                }
                else {
                    choosen.Add(y);
                    temp[y - 1] = temp[y - 1] + " ←";

                    if (rightansw[j] + 1 == y) {
                        cansw++;
                    }
                }
            }
            if (registration.Login != null) {
                string t = quest + '\n';



                for (int j = 0; j < temp.Count; j++) {
                    t = t + temp[j];
                    t = t.Trim('←');
                    if (rightansw.Contains(j)) { t = t + "^"; }
                    if (choosen.Contains(j + 1)) { t = t + "*"; }
                    t = t + '\n';
                }
                if (!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);
                }
                while (true) {
                    if (first)
                        if (File.Exists(dir + '\\' + gt + i + ".txt")) {
                            i++;
                            continue;
                        }
                        else File.Create(dir + '\\' + gt + i + ".txt").Close();
                    StreamWriter sw = new StreamWriter(dir + '\\' + gt + i + ".txt", true);
                    sw.WriteLine(t);
                    sw.Close();
                    break;
                }
            }
        }
    }
}
