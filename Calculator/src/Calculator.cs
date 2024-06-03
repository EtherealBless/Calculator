namespace Calculator;

public class Calculator
{
    private Lexer _lexer;
    private Evaluator _evaluator;


    public Calculator(string input)
    {
        _lexer = new Lexer(input);
        var tokens = _lexer.Lex();
        var postfix = InfixToPostfixConverter.Convert(tokens);
        _evaluator = new Evaluator();
        _evaluator.Compile(postfix);
    }

    public double CalculateWithVariables(Dictionary<string, double> variables)
    {
        return _evaluator.EvaluateCompiled(variables);
    }
}