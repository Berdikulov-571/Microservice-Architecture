using Telegram.Bot;

namespace TelegramBot
{
    public class BotMessage
    {
        public  ITelegramBotClient botClient;

        public  async Task Added(string data)
        {
            botClient = new TelegramBotClient("6664729300:AAExS7StUJ7Q3BuaEFKF21pg5oWttBpD2-E");

            botClient.StartReceiving();

            await botClient.SendTextMessageAsync("2017110018",$"{data} Tablesiga ma'lumot qo'shildi");
        }

        public async Task Updated(string data)
        {
            botClient = new TelegramBotClient("6664729300:AAExS7StUJ7Q3BuaEFKF21pg5oWttBpD2-E");

            botClient.StartReceiving();

            await botClient.SendTextMessageAsync("2017110018", $"{data} Tableda ma'lumot yangilandi");
        }

        public async Task Deleted(string data)
        {
            botClient = new TelegramBotClient("6664729300:AAExS7StUJ7Q3BuaEFKF21pg5oWttBpD2-E");

            botClient.StartReceiving();

            await botClient.SendTextMessageAsync("2017110018", $"{data} Tablesida ma'lumot o'chirildi");
        }
    }
}
//2017110018