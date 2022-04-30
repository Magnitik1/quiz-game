using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entering;
using дз;

namespace Вікторина2 {
    public abstract class CommandManager {
        protected ComandInfo[] comandsInfo;
        protected abstract void CreateCommandsInfo();
        public CommandManager() { CreateCommandsInfo(); }

        public void run() {
            
            while (true) {
                Command command = EnteredCommand();
                command();
                if (registration.Login != null) { Game.ChooseGame(); }
            }
        }

        private Command EnteredCommand() {
            List<string> lst = new List<string>() { comandsInfo[0].Name };
            for(int i = 1; i < comandsInfo.Length; i++) {
                lst.Add(comandsInfo[i].Name);
            }
            int num;
            do {
                Console.Clear();
                num = Entering.Choose(lst);
            } while (num<0);
            Console.Clear();
            return comandsInfo[num].Command;
        }
    }
}
