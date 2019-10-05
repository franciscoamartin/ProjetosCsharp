using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatedConsole
{
    class Animated
    {
        int counter;
        string[] sequence;

        public void ConsoleSpinner()
        {
            counter = 0;
            sequence = new string[] { "/", "-", "\\", "|" };
            sequence = new string[] { ".", "o", "0", "o" };
            sequence = new string[] { "+", "x" };
            sequence = new string[] { "V", "<", "^", ">" };
            sequence = new string[] { ".   ", "..  ", "... ", "...." };
        }

        public void Turn()
        {
            counter++;

            if (counter >= sequence.Length)
                counter = 0;

            Console.Write(sequence[counter]);
            Console.SetCursorPosition(Console.CursorLeft - sequence[counter].Length, Console.CursorTop);
        }
    }
}
