using System;

namespace WPF_MVVM_Template.Models
{
    public class Rootobject
    {
        public Coord coord { get; set; }
        public Sys sys { get; set; }
        public WeatherInfo[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int timezone { get; set; }
        public int dt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public override string ToString()
        {
            return $"Город: {name}\nВремя запроса: {new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timezone + dt)}" +
                   $"\n{sys.ToString(timezone)}\n{main.ToString()}\n{wind.ToString()}\n{coord.ToString()}\n{weather[0].ToString()}";
        }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
        public override string ToString()
        {
            return $"Широта: {lat}\nДолгота: {lon}";
        }
    }

    public class Sys
    {
        public float message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public string ToString(int timezone)
        {
            return $"Cтрана: {country}\nВосход: {new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(sunrise + timezone)}" +
                   $"\nЗакат: {new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timezone + sunset)}\n";
        }
    }

    public class Main
    {
        public float temp { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public float pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }
        public int humidity { get; set; }
        public override string ToString()
        {

            return $"Текущая температура: {temp} °C\nДавление: {Math.Round(pressure * 0.750062, 1)} мм.рт.ст";
        }
    }

    public class Wind
    {
        public float speed { get; set; }
        public float deg { get; set; }
        public override string ToString()
        {
            return $"Скорость ветра: {speed} м/с";
        }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class WeatherInfo
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public override string ToString()
        {
            return $"Погода: {description}";
        }
    }
}
