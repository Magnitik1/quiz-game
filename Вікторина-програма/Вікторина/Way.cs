using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Вікторина2 {
    class Way {
        public static string reverse(string s) {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        public static string GetNameOfWay(string way,int i1=4) {
            way=reverse(way);
            StringBuilder el=new StringBuilder();
            for(int i=i1; i < way.Length; i++) {
                if (way[i] == '\\') {way = el.ToString();
            way=reverse(way); return way; }
                el.Append(way[i]);
            }
            way = el.ToString();
            way.Reverse();
            return way;
        }
    }
}
