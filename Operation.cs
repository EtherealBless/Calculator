namespace Calculator;

class Operation : Token
{
    public Operation(char op, int precedence) : base(op.ToString())
    {
        Op = op;
        Precedence = precedence;
    }
    public char Op { get; }
    public int Precedence { get; set; }

    public override string ToString()
    {
        return Op.ToString();
    }
};
