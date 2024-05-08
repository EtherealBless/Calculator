namespace Calculator;

struct Operation
{
    public Operation(char op, int precedence)
    {
        Op = op;
        Precedence = precedence;
    }
    public char Op { get; }
    public int Precedence { get; }

    public override string ToString()
    {
        return Op.ToString();
    }
};
