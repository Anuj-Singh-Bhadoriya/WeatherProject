using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppApi.ViewModels
{

    public class MainViewModel
    {
        public WeatherViewModel WeatherVM { get; }
        public ChatMessageViewModel ChatMessageVM { get; }
        public MainViewModel()
        {
            ChatMessageVM = new ChatMessageViewModel();
            WeatherVM = new WeatherViewModel(ChatMessageVM);
        }
       
    }
}
