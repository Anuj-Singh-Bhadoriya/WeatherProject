using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherAppApi.Model
{
   public class ChatMessageModel
    {
        public String? Sender { get; set; }
        public String? Message { get; set; }
        public TimeOnly Time { get; set; }
        public bool IsUser => Sender == "User";
        public HorizontalAlignment MessageAlignment
        {
            get => IsUser
                ? HorizontalAlignment.Left
                : HorizontalAlignment.Right;
        }


    }
}
