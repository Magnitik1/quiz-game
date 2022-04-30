using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Вікторина2 {
    public delegate void Command();
    public class ComandInfo {
        public string Name;
        public Command Command;

        public ComandInfo(string name, Command command) {
            Name = name;
            Command = command;
        }
    }
}
