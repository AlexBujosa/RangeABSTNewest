using System.Text.RegularExpressions;

namespace RangeABST
{
    public class RangeASKata
    {
        public enum OpenSymbols
        {
            OpenSquareBraket = 0,
            OpenParenthesis = 1,
            None = 2

        }
        public enum CloseSymbols
        {
            CloseSquareBraket = 0,
            CloseParenthesis = 1,
            None = 2

        }
        public string newRange;
        public string saveRange;
        public int[] newRangeNumber = new int[2];
        public OpenSymbols open;
        public CloseSymbols close;

        public RangeASKata(string oldRange)
        {

            newRange = Regex.Replace(oldRange, " ", "");
            saveRange = newRange;
            CheckSymbolOpCl(newRange);
            open = OpenSymbolsAssign(newRange);
            close = CloseSymbolsAssign(newRange);
            newRange = newRange.Substring(1, newRange.Length - 2);
            string[] rangeArrayStr = newRange.Split(',');

        }

        public void CheckSymbolOpCl(string strings)
        {
            if (strings[0] != '[' && strings[1] != '(')
                throw new Exception("No contiene los simbolos de entrada correctos");
            if (strings[strings.Length -1] != ']' && strings[strings.Length - 1] != ')')
                throw new Exception("No contiene los simbolos de cerrada correctos");
        }
        public OpenSymbols OpenSymbolsAssign(string strings)
        {
            OpenSymbols openSymbols = OpenSymbols.None;
            if (strings[0] == '[')
            {
                openSymbols = OpenSymbols.OpenSquareBraket;
            }else if (strings[0] == '(')
            {
                openSymbols = OpenSymbols.OpenParenthesis;
            }
            return openSymbols;
        }
        public CloseSymbols CloseSymbolsAssign(string strings)
        {
            CloseSymbols closeSymbols = CloseSymbols.None;
            if (strings[strings.Length - 1] == ']')
            {
                closeSymbols = CloseSymbols.CloseSquareBraket;
            }
            else if (strings[strings.Length - 1] == ')')
            {
                closeSymbols = CloseSymbols.CloseParenthesis;
            }
            return closeSymbols;
        }
    }
}