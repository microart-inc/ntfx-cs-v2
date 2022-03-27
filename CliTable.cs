using MicroART.Pipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroART.NTFX.ConsoleUI
{
    class CliTable
    {
        /*
        public char TopLeft = '╔';
        public char TopRight = '╗';
        public char BottomLeft = '╚';
        public char BottomRight = '╝';
        public char Vertical = '║';
        public char Horizontal = '═';
        public char IntersectTop = '╦';
        public char IntersectBottom = '╩';
        public char IntersectLeft = '╠';
        public char IntersectRight = '╣';
        public char IntersectAll = '╬';
        */

        public char TopLeft = '+';
        public char TopRight = '+';
        public char BottomLeft = '+';
        public char BottomRight = '+';
        public char Vertical = '|';
        public char Horizontal = '-';
        public char IntersectTop = '+';
        public char IntersectBottom = '+';
        public char IntersectLeft = '+';
        public char IntersectRight = '+';
        public char IntersectAll = '+';

        public List<string> Header = new List<string>();
        public List<List<string>> Rows = new List<List<string>>();
        public CellAlign CellTextAlign;
        public bool EqualCellSpacing;
        public int EqualCellPadding;

        public enum CellAlign
        {
            Left, 
            Middle, 
            Right
        }

        public void Write()
        {
            int columns = Header.Count;
            int largestHeader = 0;
            foreach (var h in Header)
                if (h.Length > largestHeader) largestHeader = h.Length;
            largestHeader += EqualCellPadding;
            int rows = Rows.Count + 1;
            List<string> output = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                if (i == 0)
                {
                    string headerTop = TopLeft.ToString();
                    string content = Vertical.ToString();
                    foreach(var s in Header)
                    {
                        var ss = s;
                        if (EqualCellSpacing)
                        {
                            ss = AddPadding(s, largestHeader);
                        }
                        headerTop += new string(Horizontal, ss.Length);
                        headerTop += IntersectTop.ToString();
                        content += ss;

                        content += Vertical.ToString();
                    }
                    headerTop = headerTop.Substring(0, headerTop.Length - 1);
                    headerTop += TopRight.ToString();
                    new Write(headerTop, true);
                    new Write(content, true);
                }
                else if (i == rows - 1)
                {
                    string top = IntersectLeft.ToString();
                    string content = Vertical.ToString();
                    string footer = BottomLeft.ToString();
                    for (int it = 0; it < Rows[i - 1].Count; it++)
                    {
                        if (it < Header.Count)
                        {
                            var s = Rows[i - 1][it];
                            int d = Header[it].Length;
                            if (EqualCellSpacing)
                            {
                                d = largestHeader;
                            }
                            footer += new string(Horizontal, d);
                            footer += IntersectBottom.ToString();
                            s = AddPadding(s, d);
                            top += new string(Horizontal, s.Length);
                            top += IntersectAll.ToString();
                            content += s;
                            content += Vertical.ToString();
                        }
                    }
                    footer = footer.Substring(0, footer.Length - 1);
                    footer += BottomRight.ToString();
                    top = top.Substring(0, top.Length - 1);
                    top += IntersectRight.ToString();
                    //new Write(top, true);
                    new Write(content, true);
                    new Write(footer, true);

                }
                else
                {
                    string top = IntersectLeft.ToString();
                    string content = Vertical.ToString();
                    for (int it = 0; it < Rows[i - 1].Count; it++)
                    {
                        if (it < Header.Count)
                        {
                            var s = Rows[i - 1][it];
                            int d = Header[it].Length;
                            if (EqualCellSpacing)
                            {
                                d = largestHeader;
                            }
                            s = AddPadding(s, d);
                            top += new string(Horizontal, s.Length);
                            top += IntersectAll.ToString();
                            content += s;
                            content += Vertical.ToString();
                        }
                    }
                    top = top.Substring(0, top.Length - 1);
                    top += IntersectRight.ToString();
                    if (i == 1) new Write(top, true);
                    new Write(content, true);
                }
            }
        }

        private string AddPadding(string s, int padding)
        {
            if (s.Length < padding)
            {
                int left = 0;
                int right = 0;
                padding = padding - s.Length;
                if (CellTextAlign == CellAlign.Middle)
                {
                    if (padding % 2 == 0)
                    {
                        left += padding / 2;
                        right += padding / 2;
                        return $"{new string(' ', left)}{s}{new string(' ', right)}";
                    }
                    else
                    {
                        padding -= 1;
                        left += 1;
                        left += padding / 2;
                        right += padding / 2;
                        return $"{new string(' ', left)}{s}{new string(' ', right)}";
                    }
                }
                else if (CellTextAlign == CellAlign.Right)
                {
                    return $"{new string(' ', padding)}{s}";
                }
                else
                {
                    return $"{s}{new string(' ', padding)}";
                }
            }
            else if (s.Length == padding)
            {
                return s;
            }
            else
            {
                int sugpad = 1;
                if (padding - sugpad < 1)
                {
                    sugpad = 0;
                }
                var str = s.Substring(0, padding - sugpad);
                str += new string('-', padding - str.Length);
                return str;
            }
        }

    }
}
