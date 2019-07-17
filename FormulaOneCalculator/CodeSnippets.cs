using System.Collections.Generic;

namespace FormulaOneCalculator
{
    internal class CodeSnippets
    {
        internal void PositionToPointsMapper()
        {
            var mapper = new Dictionary<int, int>()
            {
                {0, 25},
                {0, 18},
                {0, 15},
                {0, 12},
                {0, 10},
                {0, 8},
                {0, 6},
                {0, 4},
                {0, 2},
                {0, 1},
            };
        }
    }

    public class WinnerPrinter
    {
        public string Print(string pilot) => $"Congratulations {pilot} with the victory!";
    }
}