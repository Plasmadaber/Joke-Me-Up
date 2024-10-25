using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Joke_Me_Up;

public partial class MainWindow : Window
{
    // initalizes application
    public MainWindow()
    {
        InitializeComponent();
        Jokes.init();
    }

    private void GetJoke(object sender, RoutedEventArgs e)
    {
        JokeText.Text = Jokes.GetJoke();
    }

    private void QuitApp(object sender, RoutedEventArgs e)
    {
        JokeText.Text = "Too Bad! YOU CAN\'T QUIT!";
    }
}
