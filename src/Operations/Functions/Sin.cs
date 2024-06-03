namespace Calculator;

public class Sin : Function
{
    public Sin(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Sin requires 1 argument");
        }
        return Math.Sin(args[0]);
    }
}