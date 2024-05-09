namespace Calculator;

public class Addition : Operation
{
    public Addition(char op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Addition requires 2 arguments");
        }
        return args[0] + args[1];
    }
}
