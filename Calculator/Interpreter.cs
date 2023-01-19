using System;
using Calculator.Types;

namespace Calculator;

internal class Interpreter
{
    public double Eval(Expression e)
    {
        return e switch
        {
            Sum sum => Eval(sum.A) + Eval(sum.B),
            Sub sub => Eval(sub.A) - Eval(sub.B),
            Mul mul => Eval(mul.A) * Eval(mul.B),
            Div div => Eval(div.A) / Eval(div.B),
            Num num => num.Value,
            _ => throw new Exception("Invalid expression")
        };
    }
}