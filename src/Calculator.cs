using System.Security.Cryptography.X509Certificates;

namespace Calculator;

public class Calculator
{


    public double Evaluate(List<Token> tokens)
    {
        var stack = new Stack<double>();

        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is Number)
            {
                stack.Push(((Number)tokens[i]).NumberValue);
            }
            if (tokens[i] is Function)
            {
                var function = (Function)tokens[i];
                double[] args = new double[function.Args];

                for (int j = 0; j < function.Args; j++)
                {
                    args[j] = stack.Pop();
                }
                stack.Push(function.Calculate(args));
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
        var lexer = new Lexer(input);
        var tokens = lexer.Lex();
        return tokens;
    }
}