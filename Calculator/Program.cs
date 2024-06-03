namespace Calculator;

public class Program
{
    public static void Main()
    {
        Evaluator calculator = new();

        Console.WriteLine("Enter an expression: ");

        string? input = Console.ReadLine();

        var lexer = new Lexer(input ?? "");

        var tokens = lexer.Lex();

        Console.WriteLine("Infix: [" + string.Join(", ", tokens) + "]");

        var postfix = InfixToPostfixConverter.Convert(tokens);

        Console.WriteLine("Postfix: [" + string.Join(", ", postfix) + "]");

        Console.WriteLine("Result: " + calculator.Evaluate(postfix));
    }
}
