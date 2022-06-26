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
            string[] strings = newRange.Split(',');
            newRangeNumber = TryParsingStringArray(strings);
            invalidRange(strings);
            isMinorOrEqualThan(newRangeNumber);


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

        public void invalidRange (string[] strings)
        {
            if(string.Length !=2)
                throw new Exception("Su rango no es valido!!");

        }

        public void isMinorOrEqualThan(int[] range)
        {
            if(range[0] > range[1])
                throw new Exception("El primer numero debe ser menor o igual al segundo");

        }
        public void TryParsingStringArray(string[] strings)
        {
            int[] creatingRange = new int[2];
            bool valido;
            for(int i =0; i < strings.Length; i++)
            {
                valido = Int32.Parse(strings[i], out int result);
                if (valido)
                    creatingRange[i] = result;
                else
                    throw new Exception("Su rango es invalido contiene valores tipo caracter");
            }
        }
    }
}