namespace Calculator;
public class Ln : Function
{
    public override int Args => 1;

    public Ln(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Ln requires 1 argument");
        }
        return Math.Log(args[0]);
    }
}