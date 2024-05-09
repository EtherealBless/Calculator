namespace Calculator;

public abstract class Operation : Token
{
    public Operation(string op, int precedence) : base()
    {
        Op = op;
        Precedence = precedence;
    }
    public string Op { get; }
    public int Precedence { get; set; }

    public abstract double Calculate(params double[] args);

    public override string ToString()
    {
        return Op.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Operation operation)
        {
            return Op == operation.Op && Precedence == operation.Precedence;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Op.GetHashCode() + Precedence;
    }

    // Personally I don't like overloading and use ==, !=, > and so on. It has no meaning and readability is degraded.
    // But it should be here because of Lab 5.
    public static bool operator ==(Operation left, Operation right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Operation left, Operation right)
    {
        return !(left == right);
    }

    public static bool operator >(Operation left, Operation right)
    {
        return left.Precedence > right.Precedence;
    }

    public static bool operator <(Operation left, Operation right)
    {
        return left.Precedence < right.Precedence;
    }

    public static bool operator >=(Operation left, Operation right)
    {
        return left.Precedence >= right.Precedence;
    }

    public static bool operator <=(Operation left, Operation right)
    {
        return left.Precedence <= right.Precedence;
    }
};
