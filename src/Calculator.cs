namespace Calculator;

public class Calculator
{

    readonly Dictionary<char, Operation> Operations = new Dictionary<char, Operation>()
    {
        {'+', new Addition('+', 1)},
        {'-', new Subtraction('-', 1)},
        {'*', new Multiplication('*', 2)},
        {'/', new Division('/', 2)},
        {'(', new LeftParenthesis('(', 0)},
        {')', new RightParenthesis(')', 0)}
    };

    public double Evaluate(List<Token> tokens)
    {
        var stack = new Stack<double>();

        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is Number)
            {
                stack.Push(((Number)tokens[i]).NumberValue);
            }
            else if (tokens[i] is Operation)
            {
                var operation = (Operation)tokens[i];
                var right = stack.Pop();
                var left = stack.Pop();
                stack.Push(operation.Calculate(left, right));
            }
        }
        return stack.Pop();
    }

    public List<Token> ParseInput(string input)
    {
        var tokens = new List<Token>();
        var number = -1f;
        var maxOperationPrecedence = Operations.Max(x => x.Value.Precedence);
        var point = false;

        foreach (var c in input)
        {
            if (c >= '0' && c <= '9')
            {
                if (number == -1)
                {
                    number = 0;
                }
                if (point)
                {
                    number += (c - '0') / 10.0f;
                }
                else
                {
                    number = number * 10 + (c - '0');
                }
                continue;
            }
            else if (c == '.')
            {
                point = true;
                continue;
            }
            if (number != -1)
            {
                tokens.Add(new Number(number));
                number = -1;
                point = false;
            }

            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')')
            {
                tokens.Add(Operations[c]);
            }
        }
        if (number != -1)
            tokens.Add(new Number(number));

        return tokens;
    }

}