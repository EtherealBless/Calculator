namespace Calculator;

class LeftParenthesis : Operation
{
    public LeftParenthesis(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        throw new NotImplementedException("Left parenthesis Calculation is not implemented");
    }
}