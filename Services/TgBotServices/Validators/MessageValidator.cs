using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WPF_MVVM_Template.Models
{
    internal class MessageValidator
    {
        public async static Task<Message> GetValidatedAnswerAsync(TelegramBot BotConfiguretion, Message Message)
        {
            var bot = BotConfiguretion.Bot;
            var db = BotConfiguretion.ClientsDB;
            var index = GetIndex(BotConfiguretion, Message);

            if (Message.Type == MessageType.Text)
            {
                if (Equals(db[index].State, State.SearchWeather) || Equals(db[index].State, State.Searching) || index < 0)
                    switch (Message.Text)
                    {
                        case Keyboard.weatherMenuButtonName:
                            if (db[index].State == State.SearchWeather) goto default;

                            db[index].State = State.SearchWeather;
                            return await bot.SendTextMessageAsync(Message.Chat.Id,
                                "Введите название города:",
                                replyMarkup: Keyboard.GetWeatherButtons());

                        case Keyboard.backButtonName:
                            db[index].State = State.Searching;
                            return await bot.SendTextMessageAsync(Message.Chat.Id,
                                "Вы возвращены в главое меню.", replyMarkup: Keyboard.GetButtons());

                        case Keyboard.connection:
                            return await bot.SendTextMessageAsync(Message.Chat.Id,
                                "Чат с создателем еще в разработке.",
                                replyMarkup: Keyboard.GetButtons());

                        default: return await WeatherHook.GetResponseAsync(bot, Message);
                    }

                return await bot.SendTextMessageAsync(Message.Chat.Id, "Что-то пошло не так:");
            }

            return await bot.SendTextMessageAsync(Message.Chat.Id, "Что-то пошло не так:");
        }

        public static int GetIndex(TelegramBot BotConfiguretion, Message Message)
        {
            var client = BotConfiguretion.ClientsDB.Where(i => i.Id == Message.Chat.Id).FirstOrDefault();

            if (client != null)
            {
                var index = BotConfiguretion.ClientsDB.IndexOf(client);
                return index;
            }
            else return -1;
        }

    }
}
