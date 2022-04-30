using entering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз {
    public static class ChooseDirictory {
        public static int dir() {
            List<string> questions = new List<string>();
            int p = 0;
            string gt = "Головна меню";
            bool prap = true;
            while (Directory.GetDirectories(Program2.way).Length >= 1) {
                foreach (var t in Directory.GetDirectories(Program2.way)) questions.Add(Program2.Way(t, 0));
                do {
                why:
                do {
                        
                    p = Entering.Choose(questions);
                        Console.Clear();
                } while (p == -2);//пока пробіл
                Console.Clear();
                    
                    if (p <= -10) {
                        RPressed(questions, p);
                        prap = false;
                        continue;
                    } 
                    if (p == -3) {
                        if (Program2.way.Substring(0, Program2.way.LastIndexOf('\\')) != "Вікторина2") {
                            //Backspace pressed
                            Program2.way = Program2.way.Substring(0, Program2.way.LastIndexOf('\\')); dir();
                        }
                        else { Console.Clear(); goto why; }
                    }
                } while (p <= -4);//поки delate
                if (p == -1) CreatingFile.create(false, gt);

                if (p < 0) break;
                gt = questions[p];
                if(prap)Program2.way = Program2.way + "\\" + gt;
                if (gt == "математика") { Console.WriteLine("Реалізація цьої вікторини буде в самому проекті"); 
                    Console.ReadKey(true); System.Environment.Exit(0); }
                questions.Clear();
            }

            questions.Clear();
            return p;
        }

        private static void RPressed(List<string> questions, int p) {
            RenameFile.renaming(questions[(p + 10) * -1]);
            questions.Clear();
            foreach (var t in Directory.GetDirectories(Program2.way)) questions.Add(Program2.Way(t, 0));
            dir();
        }
    }
}
