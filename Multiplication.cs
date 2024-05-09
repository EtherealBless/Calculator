namespace Calculator;

public class Multiplication : Operation
{
    public Multiplication(char op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Multiplication requires 2 arguments");
        }
        return args[0] * args[1];
    }
}
