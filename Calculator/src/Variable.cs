namespace Calculator;

public class Variable : Token
{
    private string _name;
    public string Name => _name;
    public Variable(string name) : base()
    {
        _name = name;
    }
    public Variable(string op, int precedence) : base()
    {
        _name = "";
    }
}