namespace Calculator;

public class Cos : Function
{
    public Cos(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Cos requires 1 argument");
        }
        return Math.Cos(args[0]);
    }
}