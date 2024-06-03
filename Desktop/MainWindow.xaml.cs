using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator;

namespace Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly StringBuilder _sb = new();

    private void btnCalculateButton_Click(object sender, RoutedEventArgs e)
    {
        _sb.Clear();
        _sb.Append(tbInputExpression.Text);
        tbInputExpression.Text = _sb.ToString();

        var variables = new Dictionary<string, double>();

        if (tbVariables.Text != "")
        {
            foreach (var variable in tbVariables.Text.Split(','))
            {
                var name = variable.Split('=')[0];
                var value = double.Parse(variable.Split('=')[1], CultureInfo.InvariantCulture);
                variables.Add(name, value);
            }
        }

        var Calculator = new Calculator.Calculator(tbInputExpression.Text);

        tbOutputExpression.Text = Calculator.CalculateWithVariables(variables).ToString();

    }

    public MainWindow()
    {
        InitializeComponent();
    }
}