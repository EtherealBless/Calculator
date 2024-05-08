Tuple<List<int>, List<char>> ParseInput(string input)
{
    var numbers = new List<int>();
    var operators = new List<char>();
    var number = 0;
    foreach (var c in input)
    {
        if (c == ' ')
        {
            if (number != -1)
            {
                numbers.Add(number);
                number = -1;
            }
        }
        else if (c == '+' || c == '-' || c == '*' || c == '/')
        {
            if (number != -1){
                numbers.Add(number);
                number = -1;
            }
            operators.Add(c);
        }
        else
        {
            if (number == -1)
            {
                number = 0;
            }
            number = number * 10 + (c - '0');
        }
    }
    numbers.Add(number);

    return new Tuple<List<int>, List<char>>(numbers, operators);
}

Console.WriteLine("Enter an expression: ");

string? input = Console.ReadLine();

var (numbers, operators) = ParseInput(input ?? "");

for (int i = 0; i < numbers.Count; i++)
{
    Console.Write(numbers[i] + " ");
}

Console.WriteLine();

for (int i = 0; i < operators.Count; i++)
{
    Console.Write(operators[i] + " ");
}
