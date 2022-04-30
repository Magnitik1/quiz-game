using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Вікторина2;
using entering;

namespace Вікторина {
    public static class WorkWithFilesAndFolders {
        public static List<string> Folders = new List<string>();
        public static List<string> Users = new List<string>();
        static string way = Program.way5;
        static string way2 = Program.way;
        public static void FindEveryFolder() {
            while (true) {

                Folders.Clear();
                Users.Clear();
                FindEveryFolder("");
                Folders.Add("математика");
                Folders.Add("випадкові");
                Folders.Add("");
                Folders.Add("Назад");
                int temp;
                do {
                    Console.Clear();
                    temp = Entering.Choose(Folders,0, Folders.Count - 2);
                    if (temp == Folders.Count - 1) { return; }
                    if (temp == -3) { Console.Clear(); return; }
                } while (temp < 0);
                FindInEveryUser(Folders[temp]);
            }
        }

        private static void FindInEveryUser(string s) {
            string[] temp = Directory.GetDirectories(way2);
            foreach (var e in temp) {
                StreamReader sr;
                try { sr = new StreamReader(e + "\\UserAnswers.txt"); } catch { continue; }
                while (true) {
                    string name;
                    name = sr.ReadLine();
                    if (name == null || name.Length < 1) { sr.Close(); break; }
                    string h = name.Substring(0, name.LastIndexOf('-') - 1);
                    if (s == h) {
                        Users.Add(FoldersName(name, " -") + " - " + FoldersName(e));
                    }
                }

            }
            int c = Users.Count;
            Users.Sort();
            Users.Reverse();
            Console.Clear();
            Console.WriteLine("\tТоп 20 в галузі «" + s + "»:");
            if (c == 0) {
                Console.WriteLine("‟Пусто‟");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine("Гравці:          Очки:");
            int min = c < 20 ? c : 20;
            for (int i = 0; i < min; i++) {
                Console.WriteLine($"{(i + 1),2}){FoldersName(Users[i], "-")}");
                Console.SetCursorPosition(20, i + 2);
                Console.WriteLine(Users[i].Substring(0, Users[i].LastIndexOf('-')).Trim('-'));
            }
            Console.ReadKey(true);
            Console.Clear();
            return;
        }

        public static string FindEveryFolder(string s) {
            string[] temp = Directory.GetDirectories(way + '\\' + s);
            if (Directory.GetFiles(way + '\\' + s).Length > 0) {
                Folders.Add(FoldersName(s));
                return "";
            }
            foreach (var e in temp) {
                if (Folders.Contains(FoldersName(e))) continue;
                string s0 = s;
                s = s + '\\' + FoldersName(e);
                FindEveryFolder(s);
                s = s0;
            }
            return s;
        }
        public static string FoldersName(string way, string s = "\\") {
            return way.Substring(way.LastIndexOf(s) + 1, way.Length - way.LastIndexOf(s) - 1);
        }
    }
}
