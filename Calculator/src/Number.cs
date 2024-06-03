namespace Calculator;

class Number : Token
{
    public Number(double number) : base()
    {
        NumberValue = number;
    }

    public double NumberValue { get; }

    public override string ToString()
    {
        return NumberValue.ToString();
    }
}