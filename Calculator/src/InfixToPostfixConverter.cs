namespace Calculator;

public class InfixToPostfixConverter
{
    public static List<Token> Convert(List<Token> infix)
    {
        List<Token> postfix = new();
        Stack<Operation> operations = new();

        for (int i = 0; i < infix.Count; i++)
        {
            // if token is number
            if (infix[i] is Number || infix[i] is Variable)
            {
                postfix.Add(infix[i]);
                continue;
            }
            // if token is function
            else if (infix[i] is Function)
            {
                operations.Push((Function)infix[i]);
                continue;
            }
            // if token is (
            else if (infix[i] is LeftParenthesis)
            {
                operations.Push((Operation)infix[i]);
            }
            // if token is )
            else if (infix[i] is RightParenthesis)
            {
                while (operations.Count > 0 && operations.Peek() is Operation && operations.Peek() is not LeftParenthesis){
                    postfix.Add(operations.Pop());
                }
                //pop '('
                operations.Pop();
            }
            // if token is operation
            else if (infix[i] is Operation)
            {
                var operation = (Operation)infix[i];

                while (operations.Count > 0 && operations.Peek() is Operation && operations.Peek().Precedence >= operation.Precedence)
                {
                    postfix.Add(operations.Pop());
                }
                operations.Push(operation);
            }
        }

        while (operations.Count > 0)
        {
            postfix.Add(operations.Pop());
        }

        return postfix;
    }
}