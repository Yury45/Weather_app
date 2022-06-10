using System;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WPF_MVVM_Template.Models
{
    internal class WeatherHook
    {
        public static string ApiKey;
        private static readonly HttpClient hc = new HttpClient();

        public static async Task<Message> GetResponseAsync(TelegramBotClient Bot, Message Message)
        {
            Uri curl = new Uri(
                $"https://api.openweathermap.org/data/2.5/weather?q={Message.Text}&lang=ru&units=metric&appid={ApiKey}");

            var request = hc.GetStreamAsync(curl);

            var result = JsonSerializer.DeserializeAsync<Rootobject>(await request);
            return await Bot.SendTextMessageAsync(Message.Chat.Id, result.ToString(),
                replyMarkup: Keyboard.GetWeatherButtons());


        }
    }
}
