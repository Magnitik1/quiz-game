using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using entering;

namespace дз {
    public static class EditFile {
        public static void edit(string gt) {
            List<string> questions = new List<string>();
            int count = Directory.GetFiles(Program2.way).Length;

            int name = 99;
            do {
                count = Directory.GetFiles(Program2.way).Length;
                List<string> arr = new List<string>();
                for(int i =0; i < count; i++) {
                    StreamReader sr = new StreamReader(Program2.way +"\\"+ (i+1)+".txt");
                    arr.Add(sr.ReadLine());
                    sr.Close();
                }
                foreach (var i in arr) {
                    questions.Add(i);
                }
                name = Entering.Choose(questions) + 1;
                if (name == -2) {//Backspace
                    Console.Clear();
                    Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\')); name = 0; 
                    ChooseDirictory.dir(); 
                    questions.Clear();
                    Console.Clear(); 
                    continue;
                }
                if (name <= -3) {//delete
                    name = -name; name -= 2;
                    File.Delete(Program2.way + "\\" + name + ".txt");
                    rename(count, name);
                    count = Directory.GetFiles(Program2.way).Length;

                    name = 0;
                    if (count <= 0) {//папака порожня - видалити її
                        Directory.Delete(Program2.way);
                        Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\'));
                        Console.Clear();
                        ChooseDirictory.dir();
                    }
                }
                if (name == 0) { questions.Clear(); Console.Clear(); }//якщо tab, то цикл заново
            } while (name == 0);//tab - створити новий тип питань, його неможна створювати серед просто питань

            if (name == -1) { //пробіл, створити нове питання
                Console.Clear(); 
                CreatingFile.create(true, gt); 
                Console.Clear();edit(gt);
            }

            while (true) {
                count = Directory.GetFiles(Program2.way).Length;
                StreamReader sr = new StreamReader(Program2.way + "\\" + name + ".txt");
                IntroductoryText(); 
                questions.Clear();
                Console.WriteLine("\t" + gt);
                int num = 0;
                while (true) {
                    string s = sr.ReadLine();
                    if (s == null) break;
                    num++;
                    questions.Add(s);
                }
                sr.Close();
                name = Entering.Choose(questions, 1);
                if (name == -3) {
                    name = BackspacePressed(gt, questions);
                }
                bool v = true;
                if (name < -3) {
                    RenamingDirecctory(ref count, ref name);
                    v = false;
                }
                if (v) {
                    EditingFile(questions, name, num);
                }
                sr.Close();
            }
        }





        private static void IntroductoryText() {
            Console.Clear();
            Console.SetCursorPosition(6, 9);
            Console.Write("Щоб вийти натисніть 'Esc'");
            Console.SetCursorPosition(6, 11);
            Console.Write("Щоб повернутись назад натисніть 'Backspace'");
            Console.SetCursorPosition(0, 0);
        }

        private static int BackspacePressed(string gt, List<string> questions) {
            int name;
            Console.Clear();
            Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\')); name = 0;
            ChooseDirictory.dir();
            questions.Clear();
            Console.Clear();
            edit(gt);
            return name;
        }

        private static void RenamingDirecctory(ref int count, ref int name) {
            name -= 3;
            File.Delete(Program2.way + "\\" + name + ".txt");
            rename(count, name);
            count = Directory.GetFiles(Program2.way).Length;
            name = 0;
            if (count <= 0) {
                Directory.Delete(Program2.way);
                Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\'));
                Console.Clear();
                ChooseDirictory.dir();
            }
        }

        private static void EditingFile(List<string> questions, int name, int num) {
            Console.Clear();
            Console.WriteLine("Перезаписати "+ questions[name-1] +" на...");
            string g = Console.ReadLine();
            if (g != "") {
                questions[name - 1] = g;
                StreamWriter sw = new StreamWriter(Program2.way + "\\" + name + ".txt");
                for (int i = 0; i < num; i++) {
                    sw.WriteLine(questions[i]);
                }
                sw.Close();
            }
        }

        public static void rename(int count, int name) {
            if (count == name) return;
            for (int i = name + 1; i <= count; i++) {
                File.Move(Program2.way + "\\" + i + ".txt", Program2.way + "\\" + (i - 1) + ".txt");
            }
        }
    }
}
