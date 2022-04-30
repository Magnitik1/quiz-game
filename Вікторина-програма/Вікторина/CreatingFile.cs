using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using entering;

namespace дз {
    public static class CreatingFile {
        public static void create(bool da, string gt) {
            if (!da) {
                CreateNewFolder(); 
            }
            int count = Directory.GetFiles(Program2.way).Length;
            List<string> questions = new List<string>();
            bool v = true;
            while (true) {
                if (v) {
                    CreateNewFile(count); 
                }
                count = Directory.GetFiles(Program2.way).Length;
                for (int i = 1; i < count + 1; i++) {
                    questions.Add(i.ToString());
                }
                Console.Clear();
                int name;
                do {
                    name = Entering.Choose(questions) + 1;
                } while (name == -1||name<-10);

                if (name == -2) {//Backspace pressed
                    Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\')); 
                    v = false; 
                    ChooseDirictory.dir(); 
                }

                if (name <= -3) { 
                    DeleteFile(ref count, ref name);
                    v = false;
                }
                questions.Clear();
                Console.Clear();
                if (name > 0) { EditFile.edit(gt); }
            }
        }




        private static void DeleteFile(ref int count, ref int name) {
            name = -name; name -= 2;
            File.Delete(Program2.way + "\\" + name + ".txt");
            EditFile.rename(count, name);
            count = Directory.GetFiles(Program2.way).Length;

            name = 0;
            if (count <= 0) {
                Directory.Delete(Program2.way);
                Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\'));
                Console.Clear();
                ChooseDirictory.dir();
            }
        }

        private static void CreateNewFile(int count) {
            Console.WriteLine("Кількість варіантів...");
            int t1 = Convert.ToInt32(Console.ReadLine());
            if (t1 <= 1) t1 = 2;
            if (t1 > 8) t1 = 8;
            StreamWriter sw2 = new StreamWriter(Program2.way + "\\" + (count + 1) + ".txt");
            Console.WriteLine("Питання:");
            sw2.WriteLine(Console.ReadLine());
            Console.WriteLine("в кінці правильного варіанту поставити символ  ^");
            for (int i = 0; i < t1; i++) {
                Console.Clear();
                Console.WriteLine("Варіант відповіді №" + (i + 1));
                sw2.WriteLine(Console.ReadLine());
            }
            sw2.Close();
        }

        private static void CreateNewFolder() {
            if (Directory.GetFiles(Program2.way).Length >= 1) {
                ChooseDirictory.dir();
            }
            Console.Clear();
            while (true) {
                Console.WriteLine("назва типу питань");
                string io = Console.ReadLine();
                if (!Directory.Exists(Program2.way + "\\" + io)) { Directory.CreateDirectory(Program2.way + "\\" + io); Program2.way = Program2.way + "\\" + io; break; }
                Console.WriteLine("Така папака вже існує");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
