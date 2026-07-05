using OpenAI.Assistants;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherAppApi.ViewModels;

namespace WeatherAppApi.Views
{
    /// <summary>
    /// Interaction logic for ChatMessageView.xaml
    /// </summary>
    public partial class ChatMessageView : UserControl
    {
        public ChatMessageView()
        {
            InitializeComponent();

            Loaded += ChatMessageView_Loaded;
        }


    

        private void ChatMessageView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ChatMessageViewModel;

            if (vm != null)
            {
                vm.Messages.CollectionChanged += Messages_CollectionChanged;
            }
        }
        private void Messages_CollectionChanged(
    object? sender,
    NotifyCollectionChangedEventArgs e)
        {
            if (ChatListBox.Items.Count > 0)
            {
                ChatListBox.ScrollIntoView(
                    ChatListBox.Items[ChatListBox.Items.Count - 1]);
            }
        }

    }
}
