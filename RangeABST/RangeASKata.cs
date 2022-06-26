using System.Text.RegularExpressions;

namespace RangeABST
{
    public class Range
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

        public Range(string oldRange)
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
        public string endPoints()
        {
            int firstValue = newRangeNumber[0];
            int secondValue = newRangeNumber[1];
            string openKey = "{";
            string closeKey = "}";
            if(OpenSymbols.OpenParenthesis == open)
            {
                firstValue += 1;
            }else if(CloseSymbols.CloseParenthesis == close)
            {
                secondValue -= 1;
            }
            return saveRange + $" endPoints = {openKey}{firstValue},{secondValue}{closeKey}";
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
            if(strings.Length !=2)
                throw new Exception("Su rango no es valido!!");

        }

        public void isMinorOrEqualThan(int[] range)
        {
            if(range[0] > range[1])
                throw new Exception("El primer numero debe ser menor o igual al segundo");

        }
        public int[] TryParsingStringArray(string[] strings)
        {
            int[] creatingRange = new int[2];
            bool valido;
            for(int i =0; i < strings.Length; i++)
            {
                valido = Int32.TryParse(strings[i], out int result);
                if (valido)
                    creatingRange[i] = result;
                else
                    throw new Exception("Su rango es invalido contiene valores tipo caracter");
            }
            return creatingRange;
        }
        public string NumberContaining(List<int> numbersContaining)
        {
            string valueString = "{";
            for(int i = 0; i<numbersContaining.Count - 2; i++)
            {
                valueString = numbersContaining[i].ToString() + ",";
            }
            valueString = numbersContaining[numbersContaining.Count - 1].ToString() + "}";
            return valueString;

        }
        public string IntegerRangeContain(List<int> values)
        {
            if(values.Count == 0)
                throw new Exception("No ingreso elementos, el conjunto esta vacio!!");
            List<int> range = ContainNumbers(newRangeNumber, open, close);
            for (int i = 0; i < values.Count; i++)
            {
                bool valid = (range.Contains(values[i])) ? true : false;
                if (!valid)
                {
                    return saveRange + " doesn't contain ";
                }
            }
            return saveRange + " contains ";

        }
        public List<int> ContainNumbers(int[] range,OpenSymbols op , CloseSymbols cl)
        {
            List<int> newRange = new List<int>();
            (int firstDigit, int secondDigit) =
                ReturnFirstSecondDigit(range, op, cl);
            for (int i = firstDigit; i<secondDigit + 1; i++)
            {
                newRange.Add(i);
            }
            return newRange;
        }
        public (int,int) ReturnFirstSecondDigit(int[] range, OpenSymbols op, CloseSymbols cl)
        {
            int firstDigit = range[0];
            int secondDigit = range[1];
            if (OpenSymbols.OpenParenthesis == op)
                firstDigit += 1;
            if (CloseSymbols.CloseParenthesis == cl)
                secondDigit -= 1;
            return (firstDigit, secondDigit);

        }
    }
}