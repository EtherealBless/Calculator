namespace Calculator;

public class Root : Function
{
    public override int Args => 2;
    public Root(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Root requires 2 arguments");
        }
        return Math.Pow(args[0], 1 / args[1]);
    }
}