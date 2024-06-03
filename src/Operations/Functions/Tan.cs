namespace Calculator;

public class Tan : Function
{
    public Tan(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Tan requires 1 argument");
        }
        return Math.Tan(args[0]);
    }
}