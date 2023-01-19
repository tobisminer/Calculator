using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Types;


namespace Calculator
{
    internal class Lexer
    {
        private static readonly Dictionary<char, Token> Keywords = new()
        {
            { '+', new Plus() },
            { '-', new Minus() },
            { '*', new Times() },
            { '/', new Divided() },
            { '(', new BracketLeft() },
            { ')', new BracketRight() },
        };

        public static List<Token> LexerCode(string input)
        {
            var output = new List<Token>();
            var token = "";
            foreach (var ch in input.Where(ch => ch != ' '))
            {
                token += ch;
                foreach (var key in Keywords.Keys.Where(key => token.EndsWith(key)))
                {
                    if (token.Length > 1) output.Add(GetNumber(token[..^key.ToString().Length]));
                    output.Add(Keywords[key]);
                    token = "";
                }
            }

            if (token.Length > 0) output.Add(GetNumber(token));
            return output;
        }

        private static Token GetNumber(string input)
        {
            if (int.TryParse(input, out var number)) return new Number(number);
            return input.ToLower() switch
            {
                "pi" => new Number(Math.PI),
                "e" => new Number(Math.E),
                _ => input.ToLower().StartsWith("sin") ? 
                    new Number(Math.Sin(DegreesToRadians(double.Parse(input[3..]))))
                    :
                    input.ToLower().StartsWith("cos") ?
                        (Token)new Number(Math.Cos(double.Parse(input[3..]))) 
                        : throw new Exception("Invalid token")
            };
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }

    
}