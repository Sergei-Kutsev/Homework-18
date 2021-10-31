using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    /*Указание: задача решается однократным проходом по символам заданной строки слева направо; для каждой открывающей скобки в строке в стек 
     помещается соответствующая закрывающая, каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека 
     (при этом скобка с вершины стека снимается); в конце прохода стек должен быть пуст.*/

    class Bracket
    {

        string[] brackets = { ")" };

        public IEnumerator GetEnumerator()
        {
            return new IEnumenatorBrackets(brackets);
        }


    }
    class IEnumenatorBrackets : IEnumerator
    {
        string[] brackets;
        int position = -1;

        public IEnumenatorBrackets(string[] brackets)
        {
            this.brackets = brackets;
        }
        public object Current
        {
            get
            { return brackets[position]; }
        }
        public bool MoveNext()
        {
            if (position < brackets.Length - 1)
            {
                position++;
                return true;
            }
            else
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
            string roundBracket = null;
            string squareBracket = null;
            string curlyBracket = null;
            string queueElement = null;
            Queue<string> brackets = new Queue<string>();
            Console.Write("Введите строку состоящую из скобок для проверки их последовательности: ");
            Bracket list = new Bracket();

            foreach (string a in list)
            {
                Console.WriteLine(a);
                if (a == "(")
                {
                    roundBracket = a;
                    brackets.Enqueue(roundBracket);
                }
                if (a == ")")
                {
                    queueElement = brackets.Dequeue();
                    if (queueElement == null)
                    { Console.WriteLine("Скобки НЕ в правильном порядке"); Console.ReadKey(); return; }
                }
                roundBracket = null;
                if (a == "[") 
                {
                    squareBracket = a; 
                }
                squareBracket = null;
                if (a == "}") 
                {
                    curlyBracket = a; 
                }
                curlyBracket = null;

            }

            foreach (string a in brackets)
            { Console.WriteLine("Скобки расставлены НЕ в правильном порядке"); Console.ReadKey(); return;}

            Console.WriteLine("Скобки расставлены в правильном порядке");
            Console.ReadKey();
        }
    }
}
