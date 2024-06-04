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
using ScottPlot.WPF;

namespace Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly StringBuilder _sb = new();
    private Calculator.Calculator _calculator;

    private Dictionary<string, double> _variables = new Dictionary<string, double>()
    {
        {"x", 0},
    };

    private void InitializeCalculator()
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

        _calculator = new Calculator.Calculator(tbInputExpression.Text);
    }

    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        InitializeCalculator();
        tbOutputExpression.Text = _calculator.CalculateWithVariables(_variables).ToString();
    }

    private void btnDrawPlot_Click(object sender, RoutedEventArgs e)
    {
        InitializeCalculator();
        WpfPlot1.Plot.Clear();
        WpfPlot1.Plot.Add.Function(func);
        WpfPlot1.Refresh();
    }
    double func(double x)
    {
        _variables["x"] = x;
        return _calculator.CalculateWithVariables(_variables);
    }

    public MainWindow()
    {
        InitializeComponent();
        _calculator = new Calculator.Calculator("");
        // WpfPlot1.Plot.Axis(-10, 10, -10, 10);
        // WpfPlot1.AxisZoom(2, 2);
    }
}