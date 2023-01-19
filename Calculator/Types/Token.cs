namespace Calculator.Types
{
    internal abstract class Token
    {
    }

    internal class BracketLeft : Token
    {
    }

    internal class BracketRight : Token
    {
    }

    internal class Plus : Token
    {
    }

    internal class Minus : Token
    {
    }

    internal class Times : Token
    {
    }

    internal class Divided : Token
    {
    }

    internal class Number : Token
    {
        public Number(double value)
        {
            Value = value;
        }

        public double Value { get; set; }
    }
}
