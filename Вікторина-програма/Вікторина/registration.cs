using entering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Вікторина;
using дз;

namespace Вікторина2 {
    class registration {
        public static string Login = null;
        public static string Pasword = null;
        public static string way = Program.way;
        public static string gt = "";
        public static void Registration() {
        o:
            Console.Clear();
            Console.WriteLine("Введіть ваш логін:");
            string s = Console.ReadLine();
            if (!Directory.Exists(way)) {
                Directory.CreateDirectory(way);
            }
            if (string.IsNullOrEmpty(s)) { Console.Clear(); return; }
            if (!Directory.Exists(way + '\\' + s)) {
                Directory.CreateDirectory(way + '\\' + s);
            }
            else {
                Console.WriteLine("Цей логін вже зайнятий, спробуйте інший");
                Console.ReadKey(true); goto o;
            }
            StreamWriter sw = new StreamWriter(way + "\\" + s + "\\UserInfo.txt");
            Console.WriteLine("\nВведіть ваш пароль:");
            string pasword = Console.ReadLine();
            sw.WriteLine(pasword);
            Console.Clear();
            Console.WriteLine("Введіть ваше ім'я:");
            pasword = Console.ReadLine();
            sw.WriteLine(pasword);
            Console.Clear();

            do {
                Console.WriteLine("Введіть вашу дату народження (dd.mm.yyyy):");
                pasword = Console.ReadLine();
                Console.Clear();
            } while (pasword.Length != 10);
            sw.WriteLine(pasword);
            sw.Close();
            Console.Clear();
        }
        public static void EnterAcaunt() {
            Console.Clear();
            Console.WriteLine("Введіть ваш логін:");
            string s1 = Console.ReadLine();
            if (string.IsNullOrEmpty(s1)) { Console.Clear(); Program.Main(null); return; }
            Console.WriteLine("\nВведіть ваш пароль:");
            string pasword = Console.ReadLine();
            if (string.IsNullOrEmpty(pasword)) { Console.Clear(); Program.Main(null); return; }
            StreamReader sr;
            if (Directory.Exists(Program.way + '\\' + s1)) {
                sr = new StreamReader(Program.way + '\\' + s1 + "\\UserInfo.txt");
            }
            else {
                Console.WriteLine("Хибний логін");
                Console.ReadKey(true);
                Console.Clear(); Program.Main(null); return;
            }


            if (sr.ReadLine() != pasword) { sr.Close(); Console.WriteLine("Логін або пароль хибний"); Console.ReadKey(true); return; }
            else {
                sr.Close();
                Pasword = pasword;
                Console.Clear(); Login = s1; Console.WriteLine("Вітаємо " + s1); Console.ReadKey(true);
            }
            Console.Clear();
            AlreadyLogined();
        }

        public static void AlreadyLogined() {
            string[] s = new string[] { "Почати гру", "Моя історія", "Списки лідерів", "Список гравців", "Змінити пароль, дату або ім'я","Вийти в головне меню" };
            int y;
            do {
                Console.Clear();
                y = Entering.Choose(s);
            } while (y < 0);
            if (y == 0) { Game.ChooseGame(); }
            if (y == 3) { Console.Clear(); list(); Console.Clear(); AlreadyLogined(); }
            if (y == 2) { WorkWithFilesAndFolders.FindEveryFolder(); Console.Clear(); AlreadyLogined(); }
            if (y == 1) { MyHistory(); Console.Clear(); AlreadyLogined(); }
            if (y == 4) { Changes(); AlreadyLogined(); }
            
            Program.Main(null);
        }

        private static void Changes() {
            string[] s = new string[] {"Змінити пароль", "Змінити дату", "Змінити ім'я","","Назад" };
            int y;
            do {
                Console.Clear();
                y = Entering.Choose(s,0,s.Length-2);
            } while (y < 0);
            if (y == 0) { ChangePasword(); }
            if (y == 1) { ChangeDate();}
            if (y == 2) { ChangeName();}
            Console.Clear();
        }

        private static void ChangeName() {
            Console.Clear();
            Console.WriteLine("Введіть пароль:");
            string s = Console.ReadLine();
            if (s != Pasword) {
                Console.Clear();
                Console.WriteLine("Хибний пароль");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine("Введіть нове ім'я:");
            do {
                s = Console.ReadLine();
            } while (s == null || s.Length < 1);
            StreamReader sr = new StreamReader(Program.way + "\\" + Login + "\\UserInfo.txt");
            string h = sr.ReadLine();
            sr.ReadLine();
            string h1 = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter(Program.way + "\\" + Login + "\\UserInfo.txt");
            sw.WriteLine(h);
            sw.WriteLine(s);
            sw.Write(h1);
            sw.Close();
        }

        private static void ChangeDate() {
            Console.Clear();
            Console.WriteLine("Введіть пароль:");
            string s = Console.ReadLine();
            if (s != Pasword) {
                Console.Clear();
                Console.WriteLine("Хибний пароль");
                Console.ReadKey(true);
                return;
            }
            do {
            Console.WriteLine("Введіть нову дату(dd.mm.yyyy):");
                s = Console.ReadLine();
                Console.Clear();
            } while (s.Length != 10);
            StreamReader sr = new StreamReader(Program.way + "\\" + Login + "\\UserInfo.txt");
            sr.ReadLine();
            string h = sr.ReadLine();
            string h1 = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter(Program.way + "\\" + Login + "\\UserInfo.txt", false);
            sw.WriteLine(registration.Pasword);
            sw.WriteLine(h);
            sw.WriteLine(h1);
            sw.Write(s);
            sw.Close();
        }

        private static void ChangePasword() {
            Console.Clear();
            Console.WriteLine("Введіть старий пароль:");
            string s=Console.ReadLine();
            if (s != Pasword) { Console.Clear();
                Console.WriteLine("Хибний пароль");
                Console.ReadKey(true);
                return; }
            Console.WriteLine("Введіть новий пароль:");
            s=Console.ReadLine();
            StreamReader sr = new StreamReader(Program.way+"\\"+Login+"\\UserInfo.txt");
            sr.ReadLine();
            string h = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(Program.way + "\\" + Login + "\\UserInfo.txt");
            sw.WriteLine(s);
            sw.Write(h);
            sw.Close();
        }

        private static void MyHistory() {
            string[] dir = Directory.GetDirectories(Program.way + '\\' + Login);
            Console.Clear();
            if (dir.Length < 1) {
                Console.WriteLine("Empty");
                Console.ReadKey(true);
                AlreadyLogined();
                return;
            }
            int i;
            List<string> temp = new List<string>();
            int dirLen = dir.Length;
            for (int y = 0; y < dirLen; y++) {
                temp.Add(WorkWithFilesAndFolders.FoldersName(dir[y]));
            }
            temp.Add("");
            temp.Add("Назад");
            do {
                i = Entering.Choose(temp,0,temp.Count-2);
                Console.Clear();
            } while (i < 0||i==temp.Count-2);
            if (i == temp.Count - 1) return;
            string[] files = Directory.GetFiles(dir[i]);
            dirLen = files.Length;
            i = -10;
            temp.Clear();
            for (int y = 0; y < dirLen; y++) {
                temp.Add(files[y].Substring(files[y].LastIndexOf('\\') + 1, 
                    files[y].Length - files[y].LastIndexOf('\\') - 5));
            }
            temp.Sort();
            //temp.Sort((x, y) => x.Length.CompareTo(y.Length));
            do {
                i = Entering.Choose(temp);
                Console.Clear();
            } while (i < 0);
            ShowFile(files[i]);
            Console.WriteLine();

            Console.Clear();
            AlreadyLogined();
        }
        private static void ShowFile(string v) {
            string s = "";
            StreamReader sr = new StreamReader(v);
            int y = 0;
            int len = File.ReadAllLines(v).Length;
            while (true) {
                s = sr.ReadLine();
                if (s == null) break;
                if (v.Contains("кольори\\кольори")) {
                    if (y != len-1) {
                        if (y % 4 == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                        if (y % 4 == 2) Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                else if (v.Contains("математика\\математика")) {
                    if (y != len-1) {
                        if (y % 3 == 1) { Console.ForegroundColor = ConsoleColor.Yellow; }
                        if (y % 3 == 2) { Console.ForegroundColor = ConsoleColor.Green; }
                    }
                }
                else {
                    if (s.Contains('^') && s.Contains('*')) Console.ForegroundColor = ConsoleColor.Green;
                    else if (s.Contains('^')) Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (s.Contains('*')) Console.ForegroundColor = ConsoleColor.Red;
                    s = s.Trim('^', '*');
                }

                Console.WriteLine(s);
                Console.ForegroundColor = ConsoleColor.White;
                y++;
            }
            sr.Close();
            Console.ReadKey(true);
        }

        public static void list() {
            if (!Directory.Exists(way)) {
                Console.WriteLine("Гравців ще немає");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            string[] w = Directory.GetDirectories(way);
            Console.WriteLine("Список гравців:");
            for (int t = 0; t < w.Length; t++) {
                Console.WriteLine("  " + w[t].Substring(w[t].LastIndexOf('\\') + 1,
                w[t].Length - w[t].LastIndexOf('\\') - 1));
            }
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
