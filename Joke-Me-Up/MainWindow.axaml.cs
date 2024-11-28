using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Speech.Synthesis;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Joke_Me_Up;

public partial class MainWindow : Window
{
    SpeechSynthesizer speech;
    // initalizes application
    public MainWindow()
    {
        InitializeComponent();
        Jokes.init();
        if(System.Environment.OSVersion.Platform == System.PlatformID.Win32NT)
        {
            speech = new SpeechSynthesizer();
            speech.SetOutputToDefaultAudioDevice();
        }
    }

    private void GetJoke(object sender, RoutedEventArgs e)
    {
        string text = Jokes.GetJoke();
        JokeText.Text = text;
        if (System.Environment.OSVersion.Platform == System.PlatformID.Win32NT)
        {
            speech.Speak(text);
        }
        Process.Start("say", text);
    }

    private void QuitApp(object sender, RoutedEventArgs e)
    {
        JokeText.Text = "Too Bad! YOU CAN\'T QUIT!";
        if (System.Environment.OSVersion.Platform == System.PlatformID.Win32NT)
        {
            speech.Speak("Too Bad! YOU CAN\'T QUIT!");
        }
        Process.Start("say", "Too Bad! YOU CAN\'T QUIT!");
    }

    public static class Jokes
    {
        private static List<string> _jokes = new List<string>();

        // Initalizes the _jokes list with all jokes from dad_jokes.csv
        public static void init()
        {
            StreamReader reader = new StreamReader(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("/Joke-Me-Up.dll", "") + "/dad_jokes.csv");

            string line = reader.ReadLine();

            while (line != null && line.Length != 0)
            {
                line = reader.ReadLine();
                if (line != null) { line = line.Substring(line.IndexOf(",") + 1).Replace("\"", ""); }
                int indexQuesMark = line.IndexOf("?");
                if (indexQuesMark != -1) { line = line.Substring(0, indexQuesMark + 1) + "\n\n" + line.Substring(indexQuesMark + 1); }
                _jokes.Add(line);
            }

            reader.Close();
        }

        // returns a random joke from _jokes
        public static string GetJoke()
        {
            Random rand = new Random();
            return _jokes[rand.Next(0, _jokes.Count)];
        }
    }
}
