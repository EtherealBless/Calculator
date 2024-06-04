using System.Collections.Specialized;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator;

public class Lexer
{

    private string _input;
    private int _position;

    readonly Dictionary<string, Token> Operations = new Dictionary<string, Token>()
    {
        {@"^\d+(\.\d+)?", new Number(0)},
        {@"^\(", new LeftParenthesis("(", 0)},
        {@"^\)", new RightParenthesis(")", 0)},
        {@"^\+", new Addition("+", 1)},
        {@"^\-", new Subtraction("-", 1)},
        {@"^\*", new Multiplication("*", 2)},
        {@"^\/", new Division("/", 2)},
        {@"^\^", new Power("^", 3)},
        {@"^sin", new Sin("sin", 3)},
        {@"^cos", new Cos("cos", 3)},
        {@"^tg", new Tan("tan", 3)},
        {@"^sqrt", new Sqrt("sqrt", 3)},
        {@"^rt", new Root("root", 3)},
        {@"^log", new Log("log", 3)},
        {@"^[a-zA-Z]", new Variable("var", 4)}
    };

    public Lexer(string input)
    {
        _input = input;
        _position = 0;
    }

    public List<Token> Lex()
    {
        var tokens = new List<Token>();
        while (_position < _input.Length)
        {
            tokens.Add(NextToken());
        }
        return tokens;
    }

    private void SkipWhitespace()
    {
        while (_position < _input.Length && (char.IsWhiteSpace(_input[_position]) || _input[_position] == ','))
        {
            _position++;
        }
    }

    public Token NextToken()
    {
        SkipWhitespace();
        if (_position >= _input.Length)
        {
            return new EOF();
        }
        foreach (var operation in Operations)
        {
            var match = Regex.Match(_input.Substring(_position), operation.Key);
            if (match.Success)
            {
                _position += match.Length;
                if (operation.Value is Number)
                {
                    return new Number(double.Parse(match.Value, CultureInfo.InvariantCulture));
                }
                if (operation.Value is Variable)
                {
                    return new Variable(match.Value);
                }
                return operation.Value;
            }
        }
        throw new ArgumentException("Token not found");
    }

    public int Position() => _position;
}