using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Вікторина;
using дз;

namespace Вікторина2 {
    class MainMenu:CommandManager {
        protected override void CreateCommandsInfo() {
            
            comandsInfo = new ComandInfo[] {
                new ComandInfo("Ввійти в свій акаунт", registration.EnterAcaunt),
                new ComandInfo("Реєстрація", registration.Registration),
                new ComandInfo("Грати як гість", Game.ChooseGame),
                new ComandInfo("Ввійти як адміністратор", AsAdmin),
                new ComandInfo("Завершити роботу", exit),
            };
        }

        void AsAdmin() {

            Console.WriteLine("Пароль:");
            if (Console.ReadLine() != "1111") {
                Console.WriteLine("Хибний пароль");
                Console.ReadKey(true);
                Console.Clear(); return;
            }Console.Clear();
            Program2.NotMain(); 
        }

        private void exit() {
            Environment.Exit(0);
        }
    }
}
