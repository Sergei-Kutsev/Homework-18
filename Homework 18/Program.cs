using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    class Bracket
    {

        string[] brackets = { "(", "{", "[", "]", "}", "]" };
        public IEnumerator<string> GetEnumerator()
        {
            return new IEnumenatorBrackets(brackets);
        }
    }
    class IEnumenatorBrackets : IEnumerator<string>
    {
        string[] brackets;
        int position = -1;
        Stack<string> Bracketlist = new Stack<string>();
        public IEnumenatorBrackets(string[] brackets)
        {
            this.brackets = brackets;
        }
        public string Current
        {
            get
            {
                return brackets[position];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();
        void RoundPush()
        {
            if (Current == "(")
            { Bracketlist.Push(")"); }
            else
            {
                try 
                { 
                    string roundBracket = Bracketlist.Pop();
                    if (roundBracket != ")") 
                    { 
                        Console.WriteLine("Скобки НЕ в правильном порядке"); 
                        Console.ReadKey(); 
                        Environment.Exit(0);
                    } 
                }
                catch (InvalidOperationException)
                { 
                    Console.WriteLine("Скобки НЕ в правильном порядке");
                    Console.ReadKey(); 
                    Environment.Exit(0);
                }
            }
        } // Обрабатывет круглые скобки, если они есть.
        void SquarePush()
        {
            if (Current == "[")
            { Bracketlist.Push("]"); }
            else
            {
                try 
                {
                    string roundBracket = Bracketlist.Pop(); 
                    if (roundBracket != "]") 
                    {
                        Console.WriteLine("Скобки НЕ в правильном порядке");
                        Console.ReadKey(); 
                        Environment.Exit(0);
                    }
                }
                catch (InvalidOperationException)
                { 
                    Console.WriteLine("Скобки НЕ в правильном порядке"); 
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }// Обрабатывет квадратные скобки, если они есть.
        void CurlyPush()
        {
            if (Current == "{")
            { Bracketlist.Push("}"); }
            else
            {
                try
                {
                    string roundBracket = Bracketlist.Pop();
                    if (roundBracket != "}")
                    {
                        Console.WriteLine("Скобки НЕ в правильном порядке");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Скобки НЕ в правильном порядке"); 
                    Console.ReadKey(); 
                    Environment.Exit(0); ;
                }
            }
        }// Обрабатывет фигурные скобки, если они есть.
        public void Dispose() { }
        public bool MoveNext()
        {
            if (position < brackets.Length - 1)
            {
                position++;
                if (Current == "(" || Current == ")") { RoundPush(); }
                if (Current == "[" || Current == "]") { SquarePush(); }
                if (Current == "{" || Current == "}") { CurlyPush(); }
                return true;
            }
            else
                foreach (string a in Bracketlist) 
                { 
                    Console.WriteLine("Скобки НЕ в правильном порядке"); 
                    Console.ReadKey(); 
                    Environment.Exit(0);
                }//Если зашли, значит коллекция Stack не пуста
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class Public
    {
        static void Main(string[] args)
        {
            
            Bracket list = new Bracket();
            foreach (string a in list)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
            Console.WriteLine("Скобки расставлены в ПРАВИЛЬНОМ порядке");
            Console.ReadKey();
        }
    }
}
