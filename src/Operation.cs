namespace Calculator;

public abstract class Operation : Token
{
    public Operation(char op, int precedence) : base()
    {
        Op = op;
        Precedence = precedence;
    }
    public char Op { get; }
    public int Precedence { get; set; }

    public abstract double Calculate(params double[] args);

    public override string ToString()
    {
        return Op.ToString();
    }
};
