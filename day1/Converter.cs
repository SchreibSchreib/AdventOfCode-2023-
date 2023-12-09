﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Converter
    {
        private string[] _numberWords = new string[]
         {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
         };

        public string GetNumber { get; }

        public Converter(string inputLine)
        {
            GetNumber = ConcatNumbers(inputLine);
        }


        //Part 1        
        //private string ConcatNumbers(string inputLine)
        //{
        //    int firstDigit = inputLine.FirstOrDefault(char.IsDigit) - '0';
        //    int secondDigit = inputLine.Reverse().FirstOrDefault(char.IsDigit) - '0';
        //    return $"{firstDigit}{secondDigit}";
        //}


        //Part 2
        private string ConcatNumbers(string inputLine)
        {
            string convertedLine = TransformLine(inputLine);
            int firstDigit = convertedLine.FirstOrDefault(char.IsDigit) - '0';
            int secondDigit = convertedLine.Reverse().FirstOrDefault(char.IsDigit) - '0';
            return $"{firstDigit}{secondDigit}";
        }

        private string TransformLine(string inputLine)
        {

            Dictionary<string, int[]> indexAndValueWord = new Dictionary<string, int[]>();

            foreach (string word in _numberWords)
            {
                if (inputLine.Contains(word))
                {
                    indexAndValueWord = GetIndexOfNumbewords(inputLine);
                }
            }

            foreach (KeyValuePair<string, int[]> indexToValue in indexAndValueWord)
            {
                foreach (int indexes in indexToValue.Value)
                {
                    inputLine = inputLine.Insert(indexes, WordNumber(indexToValue.Key).ToString());
                }
            }
            return inputLine;

        }

        private int WordNumber(string nameOfNumber)
        {
            switch (nameOfNumber)
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                default:
                    return 9;
            }
        }

        private Dictionary<string, int[]> GetIndexOfNumbewords(string inputString)
        {


            return _numberWords
            .ToDictionary(
                word => word,
                word => Enumerable.Range(0, inputString.Length - word.Length + 1)
                    .Where(i => inputString.Substring(i, word.Length).Equals(word))
                    .ToArray()
            );

        }
    }
}

