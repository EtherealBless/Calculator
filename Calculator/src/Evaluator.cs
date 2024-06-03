using System.Security.Cryptography.X509Certificates;

namespace Calculator;

public class Evaluator
{

    private List<Token> _compiledTokens;
    private Dictionary<string, int> _variables;

    public Evaluator()
    {
        _compiledTokens = new List<Token>();
        _variables = new Dictionary<string, int>();
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

    public double EvaluateWithVariables(List<Token> tokens, Dictionary<string, double> variables)
    {
        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is Variable variable)
            {
                tokens[i] = new Number(variables[variable.Name]);
            }
        }

        return Evaluate(tokens);
    }

    public void Compile(List<Token> tokens)
    {

        _compiledTokens = tokens;

        for (int i = 0; i < _compiledTokens.Count; i++)
        {
            if (_compiledTokens[i] is Variable variable)
            {
                _variables[variable.Name] = i;
            }
        }
    }


    public double EvaluateCompiled(Dictionary<string, double> variables)
    {
        for (int i = 0; i < variables.Count; i++)
        {
            _compiledTokens[_variables[variables.Keys.ElementAt(i)]] = new Number(variables[variables.Keys.ElementAt(i)]);
        }

        return Evaluate(_compiledTokens);
    }

    
}