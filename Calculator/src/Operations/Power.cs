namespace Calculator;

public class Power : Operation
{

    public Power(string op, int precedence) : base(op, precedence)
    {

    }

    public override double Calculate(params double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Power requires 2 arguments");
        }
        return Math.Pow(args[0], args[1]);
    }
}