using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppApi.Model
{
    class ChatMessageModel
    {
        public String? Sender { get; set; }
        public String? Message { get; set; }
        public TimeOnly Time { get; set; }


    }
}
