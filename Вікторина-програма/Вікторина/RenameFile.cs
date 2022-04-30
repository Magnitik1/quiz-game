using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace дз {
    class RenameFile {
        public static void renaming(string name) {
            List<string> questions = new List<string>();

            Console.Clear();
            Console.WriteLine("Замінити " + name + " на...");
            string s = Console.ReadLine();
            if (s == "") return;
            RenamingFolder(name, s);
            RenamingFolderToo(name, questions, s);
        }

        private static void RenamingFolderToo(string name, List<string> questions, string s) {
            Directory.CreateDirectory(Program2.way + '\\' + s);
            int count1 = Directory.GetFiles(Program2.way + '\\' + name).Length;
            int count2 = Directory.GetDirectories(Program2.way + '\\' + name).Length;
            int count = count1 > count2 ? count1 : count2;
            if (count2 > count1) {
                foreach (var t in Directory.GetDirectories(Program2.way + '\\' + name)) questions.Add(Program2.Way(t, 0));
            }
            else {
                foreach (var t in Directory.GetFiles(Program2.way + '\\' + name)) questions.Add(Program2.Way(t, 0));
            }
            questions.Sort();
            for (int i = 0; i < count; i++) {
                Directory.Move(Program2.way + '\\' + name + '\\' + questions[i], Program2.way + '\\' + s + '\\' + questions[i]);
            }
            Directory.Delete(Program2.way + '\\' + name);
            Console.Clear();
        }

        private static void RenamingFolder(string name, string s) {
            if (Directory.Exists(Program2.way + '\\' + s)) {
                Console.WriteLine("ця назва вже зайнята, спробуйте іншу");
                Console.ReadKey(true);
                Console.Clear();
                renaming(name);
            }
        }
    }
}
