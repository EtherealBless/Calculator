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

    public float Calculate(float left, float right)
    {
        if (Op == '+')
        {
            return left + right;
        }
        if (Op == '-')
        {
            return left - right;
        }
        if (Op == '*')
        {
            return left * right;
        }
        if (Op == '/')
        {
            return left / right;
        }
        return 0;
    }

    public override string ToString()
    {
        return Op.ToString();
    }
};
