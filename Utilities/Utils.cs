using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Security.Cryptography;
using RandomNameGeneratorLibrary;

namespace TechTyccoon2.Utilities
{
    public static class Utils
    {
        public static int Random(int beg, int end)
        {
            Random r = new Random();

            if(end <= 0)
            {
                return 0;
            }

            var i = r.Next(beg, end);

            return i;
        }
        public static List<string> ParseParameters(string str)
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
            if (breakline == true)
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

        public static string GenerateCompanyName()
        {
            List<string> suffix = new List<string>() { " Inc", string.Empty, " LLC", " Ltd.", " Corp", " Limited", " Unlimited" };

            Random r = new Random();
            var Generator = new PersonNameGenerator();
            string Name = Generator.GenerateRandomLastName();

            Name += suffix[r.Next(0, suffix.Count)];

            return Name;
        }
    }
}
