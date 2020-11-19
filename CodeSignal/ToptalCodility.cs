using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSignal
{
    class ToptalCodility
    {
        static public double maxPointsInCircle(string S, int[] x, int[] y)
        {
            var pointDict = new Dictionary<char, double>();
            double maxAllowedRadius = 0;
            for (int i = 0; i < S.Length; i++)
            {
                var tempRadius = Math.Round(getRadius(x[i], y[i]), 2);
                if (!pointDict.Keys.Contains(S[i]))
                {
                    pointDict.Add(S[i], tempRadius);
                }
                else
                {
                    var smallerRadius = tempRadius < pointDict[S[i]] ? tempRadius : pointDict[S[i]];
                    maxAllowedRadius = smallerRadius;
                }
            }
            if (maxAllowedRadius != 0)
                pointDict = pointDict.Where(kvp => kvp.Value < maxAllowedRadius).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return pointDict.Count;
        }

        static public double getRadius(int x, int y)
        {
            double radians = Math.Atan2(Math.Abs(y), Math.Abs(x));
            double angle = radians * (180 / Math.PI);
            return Math.Abs(x) / Math.Cos(angle);
        }

        static public int compress(string S)
        {
            var currentChar = S[0];
            var currentCharCounter = 0;
            var finalString = string.Empty;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == currentChar)
                    currentCharCounter++;
                else
                {
                    finalString += currentCharCounter > 1 ? (currentCharCounter).ToString() + currentChar : currentChar.ToString();
                    currentChar = S[i];
                    currentCharCounter = 1;
                }
            }
            finalString += currentCharCounter > 1 ? (currentCharCounter + 1).ToString() + currentChar : currentChar.ToString();
            return finalString.Length;
        }

        static public int compressImproved(string S, int k)
        {
            var shortestLength = compress(S);
            var length = S.Length;
            for (int i = 0; i < S.Length - 1 - k; i++)
            {
                var modifiedString = S.Replace(S.Substring(i, k), "");
                var modifiedLength = compress(modifiedString);
                if (shortestLength > modifiedLength)
                    shortestLength = modifiedLength;
            }
            return shortestLength;
        }

        static public int splitInThreeParts(string S)
        {
            var aCount = S.Split('a').Length - 1;
            if (aCount % 3 != 0) return 0;
            var validCombinations = 0;
            var lenght = S.Length;
            for (int i = 1; i <= lenght - 2; i++)
            {

                for (int j = 1; j < lenght - i; j++)
                {
                    var partA = S.Substring(0, i);
                    var partB = S.Substring(i, j);
                    var partC = S.Substring(i + j, lenght - partA.Length - partB.Length);
                    if (partA.Split('a').Length - 1 == partB.Split('a').Length - 1 &&
                        partB.Split('a').Length - 1 == partC.Split('a').Length - 1)
                    {
                        validCombinations++;
                        //Console.WriteLine(string.Format("{0}.{1}.{2}", partA, partB, partC));
                    }
                }
            }
            return validCombinations;
        }
    }
}
