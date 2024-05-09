namespace Calculator;

public class Program
{
    public static void Main()
    {
        Calculator calculator = new();

        Console.WriteLine("Enter an expression: ");

        string? input = Console.ReadLine();

        var tokens = calculator.ParseInput(input ?? "");

        Console.WriteLine("Infix: [" + string.Join(", ", tokens) + "]");

        var postfix = InfixToPostfixConverter.Convert(tokens);

        Console.WriteLine("Postfix: [" + string.Join(", ", postfix) + "]");

        Console.WriteLine("Result: " + calculator.Evaluate(postfix));
    }
}
