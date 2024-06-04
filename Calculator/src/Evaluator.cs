using System.Security.Cryptography.X509Certificates;

namespace Calculator;

public class Evaluator
{

    private List<Token> _compiledTokens;
    private Dictionary<string, double> _variables;

    public Evaluator()
    {
        _compiledTokens = new List<Token>();
        _variables = new Dictionary<string, double>();
    }

    public double Evaluate(List<Token> tokens)
    {
        var stack = new Stack<double>();

        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is Number)
            {
                stack.Push(((Number)tokens[i]).NumberValue);
            }
            else if (tokens[i] is Variable)
            {
                var variable = (Variable)tokens[i];
                stack.Push(_variables[variable.Name]);
            }
            if (tokens[i] is Function)
            {
                var function = (Function)tokens[i];
                double[] args = new double[function.Args];

                for (int j = 0; j < function.Args; j++)
                {
                    args[j] = stack.Pop();
                }
                try
                {
                    stack.Push(function.Calculate(args));
                }
                catch
                {
                    stack.Push(double.NaN);
                }
            }
            else if (tokens[i] is Operation)
            {
                var operation = (Operation)tokens[i];
                var right = stack.Pop();
                var left = stack.Pop();
                try
                {
                    stack.Push(operation.Calculate(left, right));
                }
                catch
                {
                    stack.Push(double.NaN);
                }
            }
        }

        return stack.Pop();
    }

    public double EvaluateWithVariables(List<Token> tokens, Dictionary<string, double> variables)
    {

        return Evaluate(tokens);
    }

    public void Compile(List<Token> tokens)
    {
        _compiledTokens = tokens;
    }

    public double EvaluateCompiled(Dictionary<string, double> variables)
    {
        _variables = variables;
        return EvaluateWithVariables(_compiledTokens, _variables);
    }
}