using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Telegram.Bot.Types;


namespace WPF_MVVM_Template.Models.Validators
{
    internal class StateValidator
    {
        public async static Task<Message> Validate(TelegramBot BotConfiguretion, Message Message)
        {
            int index = MessageValidator.GetIndex(BotConfiguretion, Message);
            var db = BotConfiguretion.ClientsDB;
            var bot = BotConfiguretion.Bot;

            if (db[index].Id != Message.Chat.Id)
                db.Add(new Client()
                {
                    State = State.New,
                    Id = Message.Chat.Id,
                    Messages = new ObservableCollection<Message>() { Message }
                });

            switch (db[index].State)
            {
                case State.None:
                    db[index].State = State.Searching;
                    return await bot.SendTextMessageAsync(Message.Chat.Id, "Выберите раздел:",
                        replyMarkup: Keyboard.GetButtons());

                case State.Searching:
                    if (Message.Text == Keyboard.weatherMenuButtonName)
                        return await MessageValidator.GetValidatedAnswerAsync(BotConfiguretion, Message);

                    if (Message.Text == Keyboard.connection)
                        return await bot.SendTextMessageAsync(Message.Chat.Id, "Связь с разработчиком недоступна.",
                            replyMarkup: Keyboard.GetButtons());

                    goto default;

                case State.SearchWeather:
                    return await MessageValidator.GetValidatedAnswerAsync(BotConfiguretion, Message);

                case State.New:
                    await bot.SendTextMessageAsync(Message.Chat.Id, "Добро пожаловать.",
                        replyMarkup: Keyboard.GetButtons());
                    db[index].State = State.Searching;
                    return await bot.SendTextMessageAsync(Message.Chat.Id, "Выберите раздел:",
                        replyMarkup: Keyboard.GetButtons());

                default:
                    return await bot.SendTextMessageAsync(Message.Chat.Id, "Выберите раздел:");
            }

        }
    }
}

