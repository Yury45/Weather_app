using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace WPF_MVVM_Template.Models
{
    internal class Keyboard
    {
        public const string generalHelloMessage = "Доброго время суток.";
        public const string backButtonName = "Назад";
        public const string weatherMenuButtonName = "Погода";
        public const string connection = "Связь с богом - soon";
        public const string more2ButtonName = "В \"разработке\" 2";

        public static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = Keyboard.weatherMenuButtonName }, new KeyboardButton { Text = Keyboard.connection }, },
                },
                ResizeKeyboard = true,
            };

        }
        public static IReplyMarkup GetWeatherButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = Keyboard.backButtonName  },  },
                },
                ResizeKeyboard = true,
            };
        }
    }
}
