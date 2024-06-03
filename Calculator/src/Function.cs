namespace Calculator;

public abstract class Function : Operation
{
    public virtual int Args => 1;
    public Function(string op, int precedence) : base(op, precedence)
    {
        
    }
}