using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public static class Utils
    {

        public static List<String> ParseParameters(string str)
        {
            var ret = new List<string>();
            var sb = new StringBuilder();
            bool instr = false;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (c == '\\' && ++i < str.Length)
                {
                    if (str[i] != '"' && str[i] != ' ' && str[i] != '\\')
                        sb.Append('\\');
                    sb.Append(str[i]);
                }
                else if (c == '"')
                {
                    instr = !instr;
                    if (!instr)
                    {
                        ret.Add(sb.ToString());
                        sb.Clear();
                    }
                    else if (sb.Length > 0)
                    {
                        ret.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                else if (IsWhiteSpace(c) && !instr)
                {
                    if (sb.Length > 0)
                    {
                        ret.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                else
                    sb.Append(c);
            }
            if (sb.Length > 0)
                ret.Add(sb.ToString());

            return ret;
        }

        public static void SendError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg} \n");
            Console.ForegroundColor = ConsoleColor.White;

        }

       public static void UpdateMessage(string msg)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(msg);
        }

        public static void SendSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{msg} \n");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void SendCustom(string msg, ConsoleColor color = ConsoleColor.White, bool breakline = true)
        {
            Console.ForegroundColor = color;
            if(breakline == true)
            {
                Console.WriteLine($"{msg} \n");
            }
            else
            {
                Console.WriteLine($"{msg}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static bool IsWhiteSpace(char c)
        {
            return c == ' ' || c == '\t' || c == '\n';
        }

    }
}
