using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Types
{
    internal abstract class Expression
    {
    }

    internal class Num : Expression
    {
        public double Value { get; set; }
    }

    internal class Sum : Expression
    {
        public Expression A;
        public Expression B;

        public Sum(Expression a, Expression b)
        {
            A = a;
            B = b;
        }
    }

    internal class Sub : Expression
    {
        public Expression A;
        public Expression B;

        public Sub(Expression a, Expression b)
        {
            A = a;
            B = b;
        }
    }

    internal class Mul : Expression
    {
        public Expression A;
        public Expression B;

        public Mul(Expression a, Expression b)
        {
            A = a;
            B = b;
        }
    }

    internal class Div : Expression
    {
        public Expression A;
        public Expression B;

        public Div(Expression a, Expression b)
        {
            A = a;
            B = b;
        }
    }
}
