using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MicroART.Pipe
{
    public class Write
    {
        public Write(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0, bool resetColor = true)
        {

            if (resetColor) System.Console.ResetColor();
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);

            switch (newLine)
            {
                case true:
                    System.Console.WriteLine(e);
                    return;
                case false:
                    System.Console.Write(e);
                    return;
            }
        }
        public static void NewLine(int count = 1)
        {
            Console.Write(new string('\n', count));
        }
        public static void ClearLine(int curOffsetTop = 0, int curOffsetLeft = 0)
        {
            Console.CursorTop += curOffsetTop;
            Console.CursorLeft += curOffsetLeft;
            Console.Write(new string(' ', Console.BufferWidth));
        }

        // RED
        public static void Red(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        // Black
        public static void Black(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.Black;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        // DARK GRAY
        public static void DarkGray(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.DarkGray;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        // WHITE
        public static void White(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.White;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        // PURPLE
        public static void Purple(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            if (newLine == true)
            {
                Colorful.Console.WriteLine(e, Color.FromArgb(255, 123, 31, 162));
            }
            else
            {
                Colorful.Console.Write(e, Color.FromArgb(255, 123, 31, 162));
            }
        }

        // YELLOW
        public static void Yellow(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        // Rose
        public static void Rose(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            if (newLine == true)
            {
                Colorful.Console.WriteLine(e, Color.FromArgb(239, 202, 195));
            }
            else
            {
                Colorful.Console.Write(e, Color.FromArgb(239, 202, 195));
            }
        }

        // Rose
        public static void Orange(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            if (newLine == true)
            {
                Colorful.Console.WriteLine(e, Color.FromArgb(251, 140, 0));
            }
            else
            {
                Colorful.Console.Write(e, Color.FromArgb(251, 140, 0));
            }
        }

        // BLUE
        public static void Blue(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.Blue;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        // CYAN
        public static void Cyan(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }

        internal static void Purple()
        {
            throw new NotImplementedException();
        }

        // GREEN
        public static void Green(string e, bool newLine = false, int curOffsetLeft = 0, int curOffsetTop = 0)
        {
            int Y = Console.CursorTop += curOffsetTop;
            int X = Console.CursorLeft += curOffsetLeft;
            Console.SetCursorPosition(X, Y);
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            if (newLine == true)
            {
                System.Console.WriteLine(e);
            }
            else
            {
                System.Console.Write(e);
            }
        }
    }

    public class Read
    {
        public class Console
        {
            private static TextWriter oldStdOut;
            private static StringWriter sw;
            private static DoubleWriter dw;

            public static void Start(bool Intercept)
            {
                oldStdOut = System.Console.Out;
                sw = new StringWriter();
                dw = new DoubleWriter(oldStdOut, sw, !Intercept);
                System.Console.SetOut(dw);
                System.Console.SetError(dw);
            }

            public static string Finish()
            {
                System.Console.SetOut(oldStdOut);
                string output = dw.ToString().Replace("%0A", "\n");
                dw.Dispose();
                sw.Dispose();
                return output;
            }
        }
        public static string Line()
        {
            return System.Console.ReadLine();
        }
        public static ConsoleKeyInfo Key()
        {
            return System.Console.ReadKey();
        }
        public static ConsoleKeyInfo Key(bool Intercept)
        {
            return System.Console.ReadKey(Intercept);
        }
    }
    class DoubleWriter : TextWriter
    {

        TextWriter one;
        StringWriter two;
        bool IsCopy;

        internal DoubleWriter(TextWriter one, StringWriter two, bool Intercept)
        {
            this.IsCopy = Intercept;
            this.one = one;
            this.two = two;
        }

        public override Encoding Encoding
        {
            get { return one.Encoding; }
        }

        public override void Flush()
        {
            one.Flush();
            two.Flush();
        }

        public override void Write(char value)
        {
            if (IsCopy) one.Write(value);
            two.Write(value.ToString().Replace("\n", "%0A"));
        }
        public override string ToString()
        {
            return two.ToString();
        }

    }
}
