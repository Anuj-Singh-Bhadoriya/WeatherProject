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
using WeatherAppApi.Services;

namespace WeatherAppApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        ApiService apiService = new ApiService();

        //        string city = txtPrompt.Text;

        //        WeatherList.Items.Clear();

        //        WeatherList.Items.Add($"👤 City: {city}");

        //        string weather =
        //            await apiService.GetWeatherAsync(city);

        //        WeatherList.Items.Add($"🌤 Weather: {weather}");

        //        AiService aiService = new AiService();

        //        string prompt =
        //        $"""
        //Weather in {city}: {weather}

        //Give 2 lines of advice.
        //""";

        //        ChatList.Items.Add($"👤 Ask: Weather advice for {city}");

        //        var Start = DateTime.Now;
        //        string answer =
        //            await aiService.AskAsync(prompt);
        //        var End = DateTime.Now;
        //        MessageBox.Show($"AI Time : {(End - Start).TotalSeconds} sec");

        //        ChatList.Items.Add($"🤖 AI: {answer}");

        //        ChatList.ScrollIntoView(
        //            ChatList.Items[ChatList.Items.Count - 1]);

        //        txtPrompt.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}