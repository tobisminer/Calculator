using System;
using System.Collections.Generic;
using Calculator.Types;

namespace Calculator
{
    internal class Parser
    {
        public static Expression? Parse(List<Token> tokens)
        {
            return Parse(tokens, 0, tokens.Count - 1);
        }

        public static Expression? Parse(List<Token> tokens, int start, int end)
        {
            if (tokens[start] is BracketLeft && tokens[end] is BracketRight)
            {
                start++;
                end--;
            }

            for (var operation = 0; operation <= 3; operation++)
            {
                var bracketLevel = 0;
                for (var i = start; i < end; i++)
                {
                    var token = tokens[i];
                    switch (token)
                    {
                        case BracketLeft:
                            bracketLevel++;
                            break;
                        case BracketRight:
                            bracketLevel--;
                            break;
                    }
                   
                    if (bracketLevel != 0) continue;
                    switch (token)
                    {
                        case Plus when operation == 0:
                            return new Sum(Parse(tokens, start, i - 1)!, Parse(tokens, i + 1, end)!);
                        case Minus when operation == 1:
                            return new Sub(Parse(tokens, start, i - 1)!, Parse(tokens, i + 1, end)!);
                        case Times when operation == 2:
                            return new Mul(Parse(tokens, start, i - 1)!, Parse(tokens, i + 1, end)!);
                        case Divided when operation == 3:
                            return new Div(Parse(tokens, start, i - 1)!, Parse(tokens, i + 1, end)!);
                    }
                }
            }

            if (end - start + 1 != 1)
                return null;
            if (tokens[start] is Number num)
                return new Num { Value = num.Value };
            throw new Exception("Invalid expression");
        }
    }

}