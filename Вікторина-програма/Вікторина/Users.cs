using entering;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Вікторина2;

namespace Вікторина {
    class Users {
        public static void EditUsers() {
            Console.Clear();
            string[] w = Directory.GetDirectories(Program.way);
            int t1 = 0;
            foreach (var e in w) {
                w[t1] = e.Substring(e.LastIndexOf('\\') + 1,
                    e.Length - e.LastIndexOf('\\') - 1);
                t1++;
            }
            while (true) {
                Console.Clear();

                int u = Entering.Choose(w);
                if (u >= 0) {
                    Console.Clear();
                    ShowInfo(w, u);
                    continue;
                }
                if (u <= -4) {
                    deleting(w, u);

                    w = Directory.GetDirectories(Program.way);
                    for (int t = 0; t < w.Length; t++) {
                        w[t] = w[t].Substring(w[t].LastIndexOf('\\') + 1,
                            w[t].Length - w[t].LastIndexOf('\\') - 1);
                    }
                }

            }
        }

        private static void ShowInfo(string[] w, int u) {

            StreamReader sr = new StreamReader(Program.way + '\\' + w[u] + "\\UserInfo.txt");
            sr.ReadLine();
            Console.WriteLine("Login: " + w[u] + "\nName: " + sr.ReadLine() + "\nDate: " + sr.ReadLine());
            Console.ReadKey(true);
            sr.Close();
        }

        private static void deleting(string[] w, int u) {
            u = (u + 4) * -1;
            string[] s = Directory.GetFiles(Program.way + '\\' + w[u]);
            foreach (var k in s) {
                File.Delete(k);
            }
            string[] s2 = Directory.GetDirectories(Program.way + '\\' + w[u]);
            foreach (var k in s2) {
                string[] s3 = Directory.GetFiles(Program.way + '\\' + w[u]);
                foreach (var k2 in s3) {
                    File.Delete(k2);
                }
                Directory.Delete(k);
            }
            Directory.Delete(Program.way + '\\' + w[u]);
        }
    }
}
