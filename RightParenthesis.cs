namespace Calculator;

class RightParenthesis : Operation
{
    public RightParenthesis(char op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        throw new NotImplementedException("Right parenthesis Calculation is not implemented");
    }
}