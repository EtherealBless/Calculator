Dictionary<char, int> precedence = new Dictionary<char, int>()
{
    {'+', 1},
    {'-', 1},
    {'*', 2},
    {'/', 2}
};

Tuple<List<float>, List<char>> ParseInput(string input)
{
    var numbers = new List<float>();
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
            if (number != -1)
            {
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

    return new Tuple<List<float>, List<char>>(numbers, operators);
}

float Evaluate(List<float> numbers, List<char> operators)
{
    List<int> precedences = operators.Select(x => precedence[x]).Distinct().ToList();
    precedences.Sort((x, y) => y.CompareTo(x));

    for (int i = 0; i < precedences.Count; i++)
    {
        for (int j = 0; j < operators.Count; j++)
        {
            if (precedences[i] == precedence[operators[j]])
            {
                switch (operators[j])
                {
                    case '+':
                        numbers[j] = numbers[j] + numbers[j + 1];
                        break;

                    case '-':
                        numbers[j] = numbers[j] - numbers[j + 1];
                        break;

                    case '*':
                        numbers[j] = numbers[j] * numbers[j + 1];
                        break;

                    case '/':
                        numbers[j] = numbers[j] / numbers[j + 1];
                        break;

                    default:
                        break;
                }
                numbers.RemoveAt(j + 1);
                operators.RemoveAt(j);
            }
        }
    }
    return numbers[0];

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

Console.WriteLine();

Console.WriteLine(Evaluate(numbers, operators));