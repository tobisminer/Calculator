using System.Globalization;
using System.Windows;

namespace Calculator;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CalcBtn_Click(object sender, RoutedEventArgs e)
    {
        var result = Lexer.LexerCode(InputBox.Text);
        var ast = Parser.Parse(result);
        var interpreter = new Interpreter();
        if (ast != null) ResultBox.Text = interpreter.Eval(ast).ToString(CultureInfo.InvariantCulture);
    }
}