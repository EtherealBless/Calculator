namespace Calculator;

class Number : Token
{
    public Number(float number) : base(number.ToString())
    {
        NumberValue = number;
    }

    public float NumberValue { get; }

    public override string ToString()
    {
        return NumberValue.ToString();
    }
}