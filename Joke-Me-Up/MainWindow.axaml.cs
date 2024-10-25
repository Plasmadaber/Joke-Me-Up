using Avalonia.Controls;

namespace Joke_Me_Up;

public partial class MainWindow : Window
{
    // initalizes application
    public MainWindow()
    {
        InitializeComponent();
        Jokes.init();
    }
}
