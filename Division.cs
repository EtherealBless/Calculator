namespace Calculator;

public class Division : Operation
{
    public Division(char op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Division requires 2 arguments");
        }
        return args[0] / args[1];
    }
}