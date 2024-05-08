using Calculator;

Dictionary<char, int> precedence = new Dictionary<char, int>()
{
    {'+', 1},
    {'-', 1},
    {'*', 2},
    {'/', 2}
};

Tuple<List<float>, List<Operation>> ParseInput(string input)
{
    var numbers = new List<float>();
    var operations = new List<Operation>();
    var number = 0.0f;
    var maxOperationPrecedence = precedence.Max(x => x.Value);
    var currentPrecedence = 0;
    var point = false;

    foreach (var c in input)
    {
        if (c == ' ')
        {
            if (number != -1)
            {
                numbers.Add(number);
                number = -1;
                point = false;
            }
        }
        else if (c == '+' || c == '-' || c == '*' || c == '/')
        {
            if (number != -1)
            {
                numbers.Add(number);
                number = -1;
                point = false;
            }
            operations.Add(new Operation(c, precedence[c] + currentPrecedence));
        }
        else if (c == '(')
        {
            currentPrecedence = currentPrecedence == 0 ? maxOperationPrecedence : currentPrecedence + 1;
        }
        else if (c == ')')
        {
            currentPrecedence--;
        }
        else if (c == '.')
        {
            point = true;
        }
        else
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
        }
    }
    numbers.Add(number);

    return new Tuple<List<float>, List<Operation>>(numbers, operations);
}

float Evaluate(List<float> numbers, List<Operation> operators)
{
    SortedDictionary<int, int> precedences = new();

    for (int i = 0; i < operators.Count; i++)
    {
        if (!precedences.ContainsKey(operators[i].Precedence))
            precedences[operators[i].Precedence] = 0;

        precedences[operators[i].Precedence]++;
    }


    foreach (var precedence in precedences.Reverse())
    {
        var currentPrecedence = precedence.Key;
        var currentPrecedenceCount = precedence.Value;
        for (int j = 0; j < operators.Count; j++)
        {
            if (currentPrecedenceCount == 0)
                break;
            if (precedence.Key == operators[j].Precedence)
            {
                switch (operators[j].Op)
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
                currentPrecedenceCount--;
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