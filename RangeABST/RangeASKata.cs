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

            newRange = Regex.Replace(olldRange, " ", "");
            saveRange = newRange;
            CheckSymbolOpCl(newRange);
            open = OpenSymbolsAssign(newRange);
            close = CloseSymbolsAssign(newRange);

        }

        public void CheckSymbolOpCl(string strings)
        {
            if (strings[0] != '[' && strings[1] != '(')
                throw new Exception("No contiene los simbolos de entrada correctos");
            if (strings[strings.Length -1] != ']' && strings[strings.Length - 1] != ')')
                throw new Exception("No contiene los simbolos de cerrada correctos");
        }
    }
}