namespace Calculator;

public class Sqrt : Function
{
    public override int Args => 1;
    public Sqrt(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Sqrt requires 1 argument");
        }
        return Math.Sqrt(args[0]);
    }
}