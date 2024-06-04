using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator;
using ScottPlot.WPF;
using ScottPlot;

namespace Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Calculator.Calculator _calculator;
    private Dictionary<string, double> _variables = new Dictionary<string, double>()
    {
        {"x", 0},
    };

    private void InitializeCalculator()
    {

        if (tbVariables.Text != "")
        {
            _variables = new Dictionary<string, double>();

            foreach (var variable in tbVariables.Text.Split(','))
            {
                var name = variable.Split('=')[0];
                var value = double.Parse(variable.Split('=')[1], CultureInfo.InvariantCulture);
                _variables.Add(name, value);
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

        pltPlot.Plot.Clear();
        var crosshair = pltPlot.Plot.Add.Crosshair(0, 0);
        crosshair.LineColor = Colors.Black;

        var funcPlot = pltPlot.Plot.Add.Function(func);
        funcPlot.LineColor = Colors.Red;

        pltPlot.Refresh();
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
        pltPlot.Plot.Axes.SetLimits(-10, 10, -5, 5);
        pltPlot.Plot.Axes.SquareUnits();

        var crosshair = pltPlot.Plot.Add.Crosshair(0, 0);
        crosshair.LineColor = Colors.Black;
    }
}