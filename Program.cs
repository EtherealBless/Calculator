using Calculator;

Dictionary<char, int> precedence = new Dictionary<char, int>()
{
    {'+', 1},
    {'-', 1},
    {'*', 2},
    {'/', 2}
};

List<Token> ParseInput(string input)
{
    var tokens = new List<Token>();
    var number = -1f;
    var maxOperationPrecedence = precedence.Max(x => x.Value);
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

        if (c == '+' || c == '-' || c == '*' || c == '/')
        {
            tokens.Add(new Operation(c, precedence[c]));
        }
        else if (c == '(')
        {
            tokens.Add(new LeftParenthesis());
        }
        else if (c == ')')
        {
            tokens.Add(new RightParenthesis());
        }
    }
    if (number != -1)
    tokens.Add(new Number(number));

    return tokens;
}

// TODO rewrite to Postfix Notation
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

var tokens = ParseInput(input ?? "");



