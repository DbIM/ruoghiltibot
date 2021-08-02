using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace myapp
{
    class Program
    {
        private  static string token = "";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            var me = client.GetMeAsync().Result;
            if (msg.Text != null) {
                Console.WriteLine("Получено сообщение: " + msg.Text);
              switch (msg.Text) {
                  case "hi":
                  await client.SendTextMessageAsync(msg.Chat.Id, $"Hello {msg.Chat.Username}");
                  break;

              }
            }
        }
    }
}
