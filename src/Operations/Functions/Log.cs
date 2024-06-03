namespace Calculator;

public class Log : Function
{
    public override int Args => 2;
    public Log(string op, int precedence) : base(op, precedence)
    {
    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Log requires 2 arguments");
        }
        return Math.Log(args[0], args[1]);
    }
}